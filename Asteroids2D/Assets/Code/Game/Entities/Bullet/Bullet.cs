﻿using System;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Entities.ContractsEntity;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Asteroids.Game.Entities.Bullet
{
	public class Bullet : IBullet
	{
		public event Predicate<IPoolable> onNeedToPool;
		
		public IMovable MoveComponent { get; }
		//public IEntityProvider Provider { get; }
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