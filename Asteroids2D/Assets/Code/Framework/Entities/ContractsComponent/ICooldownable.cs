using System;

namespace Asteroids.Framework.Entities.ContractsComponent
{
	public interface ICooldownable
	{
		float TimeToWait { get; }

		float TimeSpend { get; }

		event Action onTimerEnd;

		void StartTimer();
	}
}
