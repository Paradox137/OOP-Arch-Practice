using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Contracts
{
	public interface IMoveHandler : IUserInputHandler
	{
		void Handle(IAcceleratable movableObject, InputAction.CallbackContext context);
	}
	public enum MoveState
	{
		Moving,
		Stop
	};
}
