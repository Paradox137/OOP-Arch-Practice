using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Entities.ContractsEntity;
using Asteroids.Game.Entities.Bullet;
using UnityEngine;

namespace Asteroids.Game.Spawner
{
	public class BulletWeapon : IEntitiesSpawner
	{
		private readonly float bulletSpeed;
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

		public BulletWeapon(Transform spawnParent, GameObject spawnGameObject, ICooldownable spawnDelay, float bulletSpeed)
		{
			this.spawnParent = spawnParent;
			this.spawnGameObject = spawnGameObject;
			this.spawnDelay = spawnDelay;
			this.bulletSpeed = bulletSpeed;
			
			spawnDelay.onTimerEnd += ChangeToReadyState;
			isReady = true;
		}
		public E Spawn<E>(ref uint counter) where E : IBullet, new()
		{
			spawnDelay.StartTimer();
			
			GameObject gameObjectRef = Object.Instantiate(spawnGameObject, GetSpawnPosition(), GetRotation());
			
			gameObjectRef.name = nameof(E) + " " + (++counter);

			E bullet = new E();

			bullet.GameObjectRef = gameObjectRef;
			bullet.MoveComponent = new MoveComponent(gameObjectRef.transform, bulletSpeed);
			E entity = new E { GameObjectRef = gameObjectRef};

			return entity;
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
