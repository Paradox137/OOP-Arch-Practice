using System.Collections.Generic;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Listener
{
	public abstract class UserInputListener<H, C> : IUserInputListener<H>
		where H : IUserInputHandler
		where C : IGameComponent
	{
		protected readonly List<H> Handlers;
		protected readonly C ActionObject;

		protected UserInputListener(C actionObject)
		{
			this.ActionObject = actionObject;

			Handlers = new List<H>();
		}

		public void Add(H handler) => Handlers.Add(handler);
		public void Remove(H handler) => Handlers.Remove(handler);
		
		public virtual void Performed(InputAction.CallbackContext context) { Notify(context); }
		public virtual void Canceled(InputAction.CallbackContext context) { Notify(context); }
		protected virtual void Notify(InputAction.CallbackContext context) { }
	}
}
