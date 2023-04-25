using UnityEngine;

namespace Asteroids.AShootRealization
{
	public interface ISpawner
	{
		bool isReady { get; }
		
		GameObject spawnGameObject { get; }

		Transform spawnParent { get; }

		
		//Timer Component
		float Cooldown { get; }
		void Recharge();
	}
}
