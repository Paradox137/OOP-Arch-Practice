using Asteroids.Framework.Entities.ContractsEntity;
using Asteroids.Game.Pool;
using Asteroids.Game.Spawner;
using Asteroids.Game.Storage;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Factory
{
	public class EntitiesFactory<S, E> 
		where E : IEntity, IPoolable, new()
		where S : IEntitiesSpawner
	{
		private IEntityPool entityPool;
		private IEntitiesStorage entityStorage;
		private S spawner;

		private uint counter;
		
		public EntitiesFactory(IEntityPool entityPool, IEntitiesStorage entityStorage)
		{
			counter = 0;
			
			this.entityPool = entityPool;
			this.entityStorage = entityStorage;
		}

		public void TrySpawnEntity(GameObject gameObject) 
		{
			if (spawner.isReady)
			{
				IPoolable poolEntity = entityPool.TryGetEntity();
				
				if (poolEntity != null)
					poolEntity.Activate(spawner);
				else
				{
					GameObject gameObjectRef = Object.Instantiate(gameObject, spawner.GetSpawnPosition(), spawner.GetRotation());
					gameObjectRef.name = nameof(E) + " " + (++counter);

					E entity = new E { GameObjectRef = gameObjectRef };
					
					SubscribeEntity(ref entity);
					entity.Init();
				}
			}
			
		}

		private void SubscribeEntity(ref E entity)
		{
			entity.onNeedToPool += entityPool.TryAddEntity;
			entity.onActivate += entityStorage.Add;
			entity.onDeactivate += entityStorage.Remove;
		}
	}
}
