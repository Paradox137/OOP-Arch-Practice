using UnityEngine;

namespace Asteroids.Framework.Entities.Contracts
{
	public interface IRotatable : IGameComponent
	{
		Quaternion CurrentRotation { get; }
		float RotationSpeed { get; }
		void ChangeRotation(Quaternion newRotation);
	}
}
