using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Handlers
{
	public class RotateHandler : IRotateHandler
	{
		CancellationTokenSource cancellationTokenSource;
		
		public event Action<IRotatable,Vector3, CancellationToken> Rotated;

		public RotateHandler(IUserInputListener<IRotateHandler> rotateListener)
		{
			rotateListener.Add(this);
		}

		~RotateHandler()
		{
			cancellationTokenSource.Dispose();
		}

		public void Handle(IRotatable rotatableObject, Vector3 direction, InputAction.CallbackContext context)
		{
			cancellationTokenSource?.Cancel();
			
			if (context.performed)
			{
				cancellationTokenSource = new CancellationTokenSource();
				Rotated?.Invoke(rotatableObject, direction, cancellationTokenSource.Token);
			}
		}
	}
}
