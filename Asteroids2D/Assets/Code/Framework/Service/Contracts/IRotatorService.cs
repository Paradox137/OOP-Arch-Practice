using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;

namespace Asteroids.Framework.Service.Contracts
{
	public interface IRotatorService
	{
		event Action Begin;
		
		event Action<Quaternion> End;
		
		void Rotate<T>(T rotatableObject, Vector3 direction, CancellationToken cancellationToken) where T : IRotatable;
	}
}
