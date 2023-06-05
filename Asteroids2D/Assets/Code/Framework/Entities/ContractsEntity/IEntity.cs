using UnityEngine;

namespace Asteroids.Framework.Entities.ContractsEntity
{
	public interface IEntity
	{
		bool IsAlive { get;}
		GameObject GameObjectRef { get; set; }
		
		void Init();
		
		// в провайдер
		//void OnCollision();
	}
}
