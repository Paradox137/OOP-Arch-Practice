using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct MoveComponent : IMovable
	{
		private readonly Transform transform;
		public Vector3 CurrentPosition { get => transform.localPosition; private set => transform.localPosition = value; }
		public float MoveSpeed { get; }
		
		public MoveComponent(Transform transform, float moveSpeed)
		{
			this.transform = transform;
			
			MoveSpeed = moveSpeed;
		}
		public void SetPosition(Vector3 direction)
		{
			CurrentPosition += transform.TransformDirection(direction);
		}
	}
}
