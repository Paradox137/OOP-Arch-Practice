using System;
using Asteroids.Framework.Entities.ContractsComponent;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct CooldownComponent : ICooldownable
	{
		public readonly float TimeToWait { get;}
		public float TimeSpend { get; private set; }
		
		public event Action onTimerEnd;

		public CooldownComponent(float timeToWait)
		{
			TimeSpend = 0f;
			this.TimeToWait = timeToWait;
			onTimerEnd = null;
		}
		
		public async void StartTimer()
		{
			TimeSpend = 0f;
			
			await TimerTickPerDeltaTime();
			
			onTimerEnd?.Invoke();
		}

		private async UniTask TimerTickPerDeltaTime()
		{
			while (Math.Abs(TimeSpend - TimeToWait) > 0.001f)
			{
				TimeSpend += Time.deltaTime;
				await UniTask.NextFrame();
			}
		}
	}
}
