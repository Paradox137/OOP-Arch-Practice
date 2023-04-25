using System;
using System.Threading;
using Asteroids.Framework.Entities.Contracts;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Contracts
{
	public interface IRotateHandler : IUserInputHandler
	{
		event Action<IRotatable, Vector3, CancellationToken> Rotated;
		
		void Handle(IRotatable rotatableObject, Vector3 direction, InputAction.CallbackContext context);
	}
}
