using Asteroids.Framework.Entities.Contracts;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct AccelerationComponent : IAcceleratable
	{
		private readonly Transform transform;
		public Vector3 CurrentPosition { get => transform.localPosition; private set => transform.localPosition = value; }
		public float MoveSpeed { get; }
		public float AccelerationRatio { get; }
		public float SlowdownRatio { get; }
		
		public AccelerationComponent(Transform transform, float moveSpeed, float accelerationRatio, float slowdownRatio)
		{
			this.transform = transform;
			
			MoveSpeed = moveSpeed;
			AccelerationRatio = accelerationRatio;
			SlowdownRatio = slowdownRatio;
		}
		public void SetPosition(Vector3 direction)
		{
			CurrentPosition += transform.TransformDirection(direction);
		}
	}
}
