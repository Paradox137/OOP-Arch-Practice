using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service;
using Asteroids.Game.Services;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Handlers
{
	public delegate void UserRotationHandler(IRotatable rotatable, Vector3 direction, CancellationToken token);
	public class RotateHandler : IRotateHandler
	{
		private CancellationTokenSource cancellationTokenSource;

		private UserRotationHandler onRotated;

		public RotateHandler(IUserInputListener<IRotateHandler> rotateListener, UserRotationHandler rotateFunc)
		{
			rotateListener.Add(this);

			onRotated = rotateFunc;
		}

		~RotateHandler()
		{
			cancellationTokenSource.Dispose();
			
			onRotated = null;
		}

		public void Handle(IRotatable rotatableObject, Vector3 direction, InputAction.CallbackContext context)
		{
			cancellationTokenSource?.Cancel();
			
			if (context.performed)
			{
				cancellationTokenSource = new CancellationTokenSource();
				onRotated?.Invoke(rotatableObject, direction, cancellationTokenSource.Token);
			}
		}
	}
}
