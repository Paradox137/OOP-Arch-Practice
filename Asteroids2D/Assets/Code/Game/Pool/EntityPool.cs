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
		
		public bool TryAddEntity(IPoolable poolable)
		{
			if (EntitiesPool.Count < maxEntitiesInPool)
			{
				EntitiesPool.Push(poolable);
				return true;
			}
			
			return false;
		}
		
		public IPoolable TryGetEntity() => EntitiesPool.Count > 0 ? EntitiesPool.Pop() : null;
	 }
}
