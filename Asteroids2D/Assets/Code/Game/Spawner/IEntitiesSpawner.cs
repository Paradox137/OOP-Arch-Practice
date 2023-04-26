using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.ContractsComponent;
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

		ICooldownable spawnDelay { get; }
	}
}
