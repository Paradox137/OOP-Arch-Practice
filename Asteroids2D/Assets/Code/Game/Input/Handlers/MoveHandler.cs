using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service.Contracts;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Handlers
{
	public delegate void UserMoveEventHandler(IAcceleratable movableObject, CancellationToken token, MoveState moveState);
	public class MoveHandler : IMoveHandler
	{	
		private CancellationTokenSource cancellationTokenSource;

		private UserMoveEventHandler onMoved;
		
		public MoveHandler(IUserInputListener<IMoveHandler> moveListener, UserMoveEventHandler moveFunc)
		{
			moveListener.Add(this);

			onMoved = moveFunc;
		}
		
		~MoveHandler()
		{
			cancellationTokenSource.Dispose();
			
			onMoved = null;
		}

		public void Handle(IAcceleratable movableObject, InputAction.CallbackContext context)
		{
			cancellationTokenSource?.Cancel();
			
			cancellationTokenSource = new CancellationTokenSource();
			
			if (context.performed)
			{
				onMoved?.Invoke(movableObject, cancellationTokenSource.Token, MoveState.Moving);
			}
			else if (context.canceled)
			{
				onMoved?.Invoke(movableObject, cancellationTokenSource.Token, MoveState.Stop);
			}
		}
	}
}
