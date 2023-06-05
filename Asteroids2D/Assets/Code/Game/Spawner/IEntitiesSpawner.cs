using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Entities.ContractsEntity;
using Asteroids.Game.Entities.Bullet;
using UnityEngine;

namespace Asteroids.Game.Spawner
{
	public interface IEntitiesSpawner
	{
		bool isReady { get; }
		//E Spawn<E>(ref uint counter) where E : IBullet, new();
		Transform spawnParent { get; }
		Vector3 GetSpawnPosition();
		Quaternion GetRotation();
		GameObject spawnGameObject { get; }
		ICooldownable spawnDelay { get; }
	}
}
