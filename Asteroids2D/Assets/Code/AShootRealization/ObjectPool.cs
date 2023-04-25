using System;
using System.Collections.Generic;
using Asteroids.Framework.Entities;
using UnityEngine;

namespace Asteroids.AShootRealization
{
	 public class ObjectPool : IObjectPool
	 {
		private Stack<IPoolable> EntitiesPool;

		private uint maxEntitiesInPool;
		
		public ObjectPool(uint maxEntitiesInPool)
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
