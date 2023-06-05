using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct AccelerationComponent : IAcceleratable
	{
		private readonly Transform _transform;
		public Vector3 CurrentPosition { get => _transform.localPosition; private set => _transform.localPosition = value; }
		public float MoveSpeed { get; }
		public float AccelerationRatio { get; }
		public float SlowdownRatio { get; }

		public AccelerationComponent(Transform transform, float moveSpeed, float accelerationRatio, float slowdownRatio)
		{
			this._transform = transform;

			MoveSpeed = moveSpeed;
			AccelerationRatio = accelerationRatio;
			SlowdownRatio = slowdownRatio;
		}
		public void SetPosition(Vector3 direction)
		{
			CurrentPosition += _transform.TransformDirection(direction);
		}
	}
}
