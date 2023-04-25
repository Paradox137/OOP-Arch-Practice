using UnityEngine;

namespace Asteroids.Framework.Entities.ContractsComponent
{
	public interface IRotatable : IGameComponent
	{
		Quaternion CurrentRotation { get; }
		float RotationSpeed { get; }
		void ChangeRotation(Quaternion newRotation);
	}
}
