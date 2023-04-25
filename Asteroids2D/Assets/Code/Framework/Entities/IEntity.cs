using System;
using UnityEngine;

namespace Asteroids.Framework.Entities
{
	public interface IEntity
	{
		bool IsAlive { get;}
		GameObject GameObjectRef { get; set; }
		
		void Init();
		void OnCollision();
	}
}
