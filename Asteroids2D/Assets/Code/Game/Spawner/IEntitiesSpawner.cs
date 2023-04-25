using UnityEngine;

namespace Asteroids.Game.Spawner
{
	public interface IEntitiesSpawner
	{
		bool isReady { get; }
		Transform spawnParent { get; }
		Vector3 GetSpawnPosition();
		Quaternion GetRotation();
		
		GameObject spawnGameObject { get; }
		//Timer Component
		float Cooldown { get; }
		void Recharge();
	}
}
