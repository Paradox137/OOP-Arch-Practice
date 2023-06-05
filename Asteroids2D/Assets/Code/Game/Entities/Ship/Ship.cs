using System;
using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Game.Spawner;
using UnityEngine;

namespace Asteroids.Game.Entities.Ship
{
	public class Ship : IShip
	{
		public bool IsAlive { get; private set; }
		public GameObject GameObjectRef { get; set; }
		public IRotatable RotateComponent { get; }
		public IAcceleratable AccelerateComponent { get; }
		public IFactoryable FactoryComponent { get; private set; }
		public Ship(IRotatable rotateComponent, IAcceleratable accelerateComponent, GameObject gameObjectRef, IFactoryable factoryComponent)
		{
			RotateComponent = rotateComponent;
			AccelerateComponent = accelerateComponent;
			GameObjectRef = gameObjectRef;
			FactoryComponent = factoryComponent;
		}
		public void Init()
		{
			IsAlive = true;
		}
		public void OnCollision()
		{
			
		}
	}
}
