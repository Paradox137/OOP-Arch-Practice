using System;
using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;

namespace Asteroids.Game.Entities.Ship
{
	public class Ship : IShip
	{
		public bool IsAlive { get; private set; }
		public GameObject GameObjectRef { get; set; }
		public IRotatable RotateComponent { get; }
		public IAcceleratable AccelerateComponent { get; }
		public Ship(IRotatable rotateComponent, IAcceleratable accelerateComponent, GameObject gameObjectRef)
		{
			RotateComponent = rotateComponent;
			AccelerateComponent = accelerateComponent;
			GameObjectRef = gameObjectRef;
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
