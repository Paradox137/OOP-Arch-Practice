using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Contracts
{
	public interface IUserInputListener<H> 
		where H : IUserInputHandler
	{
		void Add(H handler);
		
		void Remove(H handler);
		
		void Performed(InputAction.CallbackContext context);
		
		void Canceled(InputAction.CallbackContext context);
	}
}
