using UnityEngine;

namespace Asteroids.Framework.Entities.Contracts
{
	public interface IAcceleratable : IMovable
	{
		float AccelerationRatio { get; }
		float SlowdownRatio { get; }
	}
}
