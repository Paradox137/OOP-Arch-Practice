using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using UnityEngine;

namespace Asteroids.Framework.Service.Contracts
{
	public interface IMoverWithAccelerationService
	{
		event Action Begin;
		
		event Action<Vector3> End;
		
		void MoveWithAcceleration<T>(T movableObject, CancellationToken cancellationToken, MoveState moveState) where T : IAcceleratable;
		
		//void Move<T>(T movableObject, CancellationToken cancellationToken) where T : IMovable;
	}
}
