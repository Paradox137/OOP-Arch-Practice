using Asteroids.Framework.Entities.ContractsComponent;
using Mono.Cecil;
using UnityEngine;

namespace Asteroids.Game.Spawner
{
	public class BulletWeapon : IEntitiesSpawner
	{
		public bool isReady { get; private set; }
		public Transform spawnParent { get; }
		public GameObject spawnGameObject { get; }
		public ICooldownable spawnDelay { get; }
		public Vector3 GetSpawnPosition()
		{
			return Vector3.zero;
		}
		public Quaternion GetRotation()
		{
			return Quaternion.identity;
		}

		public BulletWeapon(Transform spawnParent, GameObject spawnGameObject, ICooldownable spawnDelay)
		{
			this.spawnParent = spawnParent;
			this.spawnGameObject = spawnGameObject;
			this.spawnDelay = spawnDelay;
			
			spawnDelay.onTimerEnd += ChangeToReadyState;
			isReady = true;
		}
		
		~BulletWeapon()
		{
			spawnDelay.onTimerEnd -= ChangeToReadyState;
		}

		private void ChangeToReadyState()
		{
			isReady = true;
		}
	}
}
