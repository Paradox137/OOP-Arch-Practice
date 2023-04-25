using System.Collections.Generic;
using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Pool
{
	 public class EntityPool : IEntityPool
	 {
		private Stack<IPoolable> EntitiesPool;

		private uint maxEntitiesInPool;
		
		public EntityPool(uint maxEntitiesInPool)
		{
			EntitiesPool = new Stack<IPoolable>();

			this.maxEntitiesInPool = maxEntitiesInPool;
		}

		// когда умрёт мы постараемчя добавить сюда
		public bool TryAddToPool(IPoolable poolable)
		{
			if (EntitiesPool.Count < maxEntitiesInPool)
			{
				EntitiesPool.Push(poolable);
				poolable.Deactivate();
				return true;
			}
			
			return false;
		}
	}
}
