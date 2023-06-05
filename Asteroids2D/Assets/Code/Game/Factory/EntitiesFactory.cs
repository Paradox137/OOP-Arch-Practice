using Asteroids.Framework.Entities.ContractsEntity;
using Asteroids.Game.Pool;
using Asteroids.Game.Spawner;
using Asteroids.Game.Storage;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Factory
{
	public abstract class EntitiesFactory<S, E> : IEntitiesFactory
		where E : IEntity, IPoolable, new()
		where S : IEntitiesSpawner
	{
		private IEntityPool entityPool;
		private IEntityStorage entityStorage;
		protected S spawner;
		readonly int _horse;
		protected uint counter;

		protected EntitiesFactory(IEntityPool entityPool, IEntityStorage entityStorage, S spawner)
		{
			counter = 0;

			this.entityPool = entityPool;
			this.entityStorage = entityStorage;
			this.spawner = spawner;
		}
		public void TrySpawnEntity(GameObject gameObject)
		{
			if (spawner.isReady)
			{
				IPoolable poolEntity = entityPool.TryGetEntity();

				if (poolEntity != null)
					poolEntity.Activate(spawner);
				else
					SpawnEntity();
			}
		}

		public virtual void SpawnEntity()
		{
			
		}

		protected void SubscribeEntity(ref E entity)
		{
			entity.onNeedToPool += entityPool.TryAddEntity;
			entity.onActivate += entityStorage.Add;
			entity.onDeactivate += entityStorage.Remove;
		}
	}
}
