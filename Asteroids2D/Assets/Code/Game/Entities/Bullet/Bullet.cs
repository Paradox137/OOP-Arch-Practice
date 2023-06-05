using System;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Entities.ContractsEntity;
using Asteroids.Game.Spawner;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Entities.Bullet
{
	public class Bullet : IBullet
	{ 
		public event Predicate<IPoolable> onNeedToPool;
		public event Action<IEntity> onActivate;
		public event Action<IEntity> onDeactivate;
		public IMovable MoveComponent { get; set; }
		public GameObject GameObjectRef { get; set; }
		public bool IsAlive { get; private set; }
		
		//public IEntityProvider Provider { get; }
		public void Activate(IEntitiesSpawner spawner)
		{
			
		}
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
			
		}
		public void Init()
		{
			
		}
		public void OnCollision()
		{
			Object.Destroy(GameObjectRef);
		}
	}
}
