using System;
using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.Contracts;
using Asteroids.ShootModule;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.AShootRealization
{
	public class Bullet : IPoolable, IEntity, IProjectile
	{
		public event Predicate<IPoolable> onNeedToPool;
		
		public IMovable MoveComponent { get; }
		public IEntityProvider Provider { get; }
		public bool IsAlive { get; private set; }
		public GameObject GameObjectRef { get; set; }
		
		public void Activate()
		{
			
		}
		public void Deactivate() 
		{
			IsAlive = false;
			GameObjectRef.SetActive(false);
		}
		
		public void RemoveFromPool()
		{
			throw new NotImplementedException();
		}
		public void Init()
		{
			
		}
		public void OnCollision()
		{
			onNeedToPool = null;
			Object.Destroy(GameObjectRef);
			throw new NotImplementedException();
		}
	}
}
