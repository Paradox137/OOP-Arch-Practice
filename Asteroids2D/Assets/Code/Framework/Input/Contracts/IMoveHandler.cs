using System;
using System.Threading;
using Asteroids.Framework.Entities.Contracts;
using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Contracts
{
	public interface IMoveHandler : IUserInputHandler
	{
		event Action<IAcceleratable, CancellationToken, MoveState> Moved;
		
		//event Action<IMovable, CancellationToken, MoveState> StopMoved;
		
		void Handle(IAcceleratable movableObject, InputAction.CallbackContext context);
	}
	public enum MoveState
	{
		Moving,
		Stop
	};
}
