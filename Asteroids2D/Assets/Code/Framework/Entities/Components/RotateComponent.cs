using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct RotateComponent : IRotatable
	{
		private readonly Transform transform;
		public Quaternion CurrentRotation { get => transform.rotation; private set => transform.rotation = value; }
		public float RotationSpeed { get; }

		public RotateComponent(Transform transform, float rotationSpeed)
		{
			this.transform = transform;
			
			RotationSpeed = rotationSpeed;
		}
		public void ChangeRotation(Quaternion newEuler)
		{
			CurrentRotation = newEuler;
		}
	}
}
