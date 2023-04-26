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
		private S spawnableInfo;

		private uint counter;
		
		public EntitiesFactory(IEntityPool entityPool, IEntitiesStorage entityStorage)
		{
			counter = 0;
			
			this.entityPool = entityPool;
			this.entityStorage = entityStorage;
		}

		public void SpawnEntity(GameObject gameObject) 
		{
			
			GameObject gameObjectRef = 
				Object.Instantiate(gameObject, spawnableInfo.GetSpawnPosition(), spawnableInfo.GetRotation());

			gameObjectRef.name = nameof(E) + " " + (++counter);

			E entity = new E { GameObjectRef = gameObjectRef };

			entity.onNeedToPool += entityPool.TryAddEntity;
			
			entity.Init();
		}
	}
}
