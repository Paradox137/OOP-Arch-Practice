using System;
using Asteroids.AShootRealization;
using Asteroids.Framework.Entities;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Services
{
	public class Spawner<S, E> 
		where E : IEntity, IPoolable, new()
		where S : ISpawnable
	{
		private IObjectPool objectPool;
		private S spawnableInfo;

		private uint counter;
		
		public Spawner(IObjectPool objectPool)
		{
			counter = 0;
			this.objectPool = objectPool;
		}

		public void SpawnEntity(GameObject gameObject) 
		{
			GameObject gameObjectRef = 
				Object.Instantiate(gameObject, spawnableInfo.GetSpawnPosition(), spawnableInfo.GetRotation());

			gameObjectRef.name = nameof(E) + " " + (++counter);

			E entity = new E { GameObjectRef = gameObjectRef };

			entity.onNeedToPool += objectPool.TryAddToPool;
			
			entity.Init();
		}
	}
}
