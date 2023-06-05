using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service;
using Asteroids.Framework.Service.Contracts;
using Cysharp.Threading.Tasks;
using UnityEngine;
// ReSharper disable MethodSupportsCancellation

namespace Asteroids.Game.Services
{
	public class AccelerationMover : IMoverWithAccelerationService, IGameService
	{
		private float momentSpeed;
		private float currentAccelerationRatio;
		
		public event Action Begin;
		public event Action<Vector3> End;

		public async void MoveWithAcceleration<T>(T movableObject, CancellationToken cancellationToken, MoveState moveState)
			where T : IAcceleratable
		{
			End += movableObject.SetPosition;
			
			await MoveWithAccelerationEveryFrame(movableObject, cancellationToken, moveState);

			End -= movableObject.SetPosition;
		}

		private async UniTask MoveWithAccelerationEveryFrame<T>(T movableObject, CancellationToken cancellationToken, MoveState moveState)
			where T : IAcceleratable
		{
			Begin?.Invoke();
			
			while (!cancellationToken.IsCancellationRequested)
			{
				ChangeAccelerationRatio(movableObject, moveState);
				momentSpeed = GetMomentSpeed(movableObject.MoveSpeed, currentAccelerationRatio);
				Vector3 localDirection = Vector3.up * momentSpeed * Time.deltaTime;
				
				End?.Invoke(localDirection);
				
				if(moveState == MoveState.Stop && momentSpeed == 0) break;
				await UniTask.NextFrame();
			}
		}
		private static float GetMomentSpeed(float moveSpeed, float accelerationRatio) => moveSpeed * accelerationRatio;
		private void ChangeAccelerationRatio<T> (T acceleratable, MoveState moveState1)
			where T : IAcceleratable
		{
			currentAccelerationRatio += ((moveState1 == MoveState.Moving) ?
				acceleratable.AccelerationRatio : -acceleratable.SlowdownRatio) * Time.deltaTime;
			currentAccelerationRatio = Mathf.Clamp01(currentAccelerationRatio);
		}
		
	}
}
