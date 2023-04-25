using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Service;
using Asteroids.Framework.Service.Contracts;
using Cysharp.Threading.Tasks;
using UnityEngine;
// ReSharper disable once MethodSupportsCancellation

namespace Asteroids.Game.Services
{
	public class Rotator : IRotatorService, IGameService
	{
		public event Action Begin;

		public event Action<Quaternion> End;

		private async UniTask RotateEveryFrame<T>(T rotatableObject, Vector3 direction, CancellationToken cancellationToken) 
			where T : IRotatable
		{
			Begin?.Invoke();
			
			while (!cancellationToken.IsCancellationRequested)
			{
				Quaternion quaternion = NewQuaternion(rotatableObject, direction);

				End?.Invoke(quaternion);
				
				await UniTask.NextFrame();
			}
		}
		private static Quaternion NewQuaternion<T>(T rotatable, Vector3 vector3)
			where T : IRotatable
		{
			Quaternion quaternion = rotatable.CurrentRotation *
				UnityEngine.Quaternion.Euler(vector3 * rotatable.RotationSpeed * Time.deltaTime);
			return quaternion;
		}
		public async void Rotate<T>(T rotatableObject, Vector3 direction, CancellationToken cancellationToken) 
			where T : IRotatable
		{
			End += rotatableObject.ChangeRotation;

			await RotateEveryFrame(rotatableObject, direction, cancellationToken);

			End -= rotatableObject.ChangeRotation;
		}
	}
}
