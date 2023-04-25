using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Handlers
{
	public class MoveHandler : IMoveHandler
	{	
		CancellationTokenSource cancellationTokenSource;
		
		public event Action<IAcceleratable, CancellationToken, MoveState> Moved;

		public MoveHandler(IUserInputListener<IMoveHandler> moveListener)
		{
			moveListener.Add(this);
		}

		~MoveHandler()
		{
			cancellationTokenSource.Dispose();
		}
		
		public void Handle(IAcceleratable movableObject, InputAction.CallbackContext context)
		{
			cancellationTokenSource?.Cancel();
			
			cancellationTokenSource = new CancellationTokenSource();
			
			if (context.performed)
			{
				Moved?.Invoke(movableObject, cancellationTokenSource.Token, MoveState.Moving);
			}
			else if (context.canceled)
			{
				Moved?.Invoke(movableObject, cancellationTokenSource.Token, MoveState.Stop);
			}
		}
	}
}
