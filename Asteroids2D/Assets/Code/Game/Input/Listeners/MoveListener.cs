using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Input.Listener;
using Asteroids.Framework.Service.Contracts;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Listeners
{
	public class MoveListener : UserInputListener<IMoveHandler, IAcceleratable>
	{
		public MoveListener(UserInputActions userInputActions, IAcceleratable movableObject)
			: base(movableObject)
		{
			userInputActions.Player.Move.performed += Performed;
			userInputActions.Player.Move.canceled += Canceled;
		}
		
		protected override void Notify(InputAction.CallbackContext context)
		{
			foreach (IMoveHandler handler in Handlers)
			{
				handler.Handle(ActionObject, context);
			}
		}
	}
}
