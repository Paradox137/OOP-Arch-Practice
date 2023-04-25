using Asteroids.Framework.Entities.Contracts;
using Asteroids.Framework.Input;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Input.Listener;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Game.Input.Listeners
{
	public class RotateListener : UserInputListener<IRotateHandler, IRotatable>
	{
		public RotateListener(UserInputActions userInputActions, IRotatable rotatableObject)
			: base(userInputActions, rotatableObject)
		{
			userInputActions.Player.Rotate.performed += Performed;
			userInputActions.Player.Rotate.canceled += Canceled;
		}
		protected override void Notify(InputAction.CallbackContext context)
		{
			Vector3 direction = -context.ReadValue<Vector2>().x * Vector3.forward;

			foreach (IRotateHandler handler in Handlers)
			{
				handler.Handle(ActionObject, direction, context);
			}
		}
	}
}
