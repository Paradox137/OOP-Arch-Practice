using UnityEngine;

namespace Asteroids.Framework.Entities.Contracts
{
	public interface IMovable : IGameComponent
	{
		Vector3 CurrentPosition { get; }
		
		float MoveSpeed { get; }

		void SetPosition(Vector3 direction);
	}
}
