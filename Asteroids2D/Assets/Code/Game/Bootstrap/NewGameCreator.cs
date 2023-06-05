using System;
using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Input;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service.Contracts;
using Asteroids.Game.Entities.Ship;
using Asteroids.Game.Factory;
using Asteroids.Game.Input;
using Asteroids.Game.Input.Handlers;
using Asteroids.Game.Input.Listeners;
using Asteroids.Game.Pool;
using Asteroids.Game.Services;
using Asteroids.Game.Spawner;
using Asteroids.Game.Storage;
using UnityEngine;

namespace Asteroids.Game.Bootstrap
{
	public class NewGameCreator : MonoBehaviour
	{
		[SerializeField] private GameObject shipGameObject;
		[SerializeField] private Transform spawnBulletsParent;
		[SerializeField] private GameObject bulletGameObject;
		[SerializeField] private float timeToWait;
		[SerializeField] private float bulletSpeed;
		[SerializeField] private uint maximumBulletsInPool;
		private UserInputActions inputActions;
		void Awake()
		{
			InitializePlayerInput();
		}

		void OnEnable()
		{
			inputActions?.Enable();
		}

		void OnDisable()
		{
			inputActions?.Disable();
		}
		
		private void InitializePlayerInput()
		{
			inputActions = new UserInputActions();
			
			ICooldownable spawnDelay = new CooldownComponent(timeToWait);
			BulletWeapon bulletWeapon = new BulletWeapon(spawnBulletsParent, bulletGameObject, spawnDelay, bulletSpeed);
			
			IEntityStorage entityStorage = new EntityStorage();
			IEntityPool entityPool = new EntityPool(maximumBulletsInPool);
			BulletFactory bulletFactory = new BulletFactory(entityPool, entityStorage, bulletWeapon);
			IFactoryable factoryComponent = new FactoryComponent(bulletFactory);

			IRotatable rotateComponent = new RotateComponent(shipGameObject.transform, 200);
			IAcceleratable moveComponent = new AccelerationComponent(shipGameObject.transform, 5f, 0.85f, 0.6f);
			IShip ship = new Ship(rotateComponent, moveComponent, shipGameObject, factoryComponent);
			
			
			// вынести куда то? типо params и там лист создаётся этих сервсисов
			// НЕТ это же системы под копабль
			AccelerationMover moverService = new AccelerationMover();
			Rotator rotator = new Rotator();
					
			RotateListener rotateListener = new RotateListener(inputActions, ship.RotateComponent);
			IRotateHandler rotateHandler = new RotateHandler(rotateListener, rotator.Rotate);	
				
			MoveListener moveListener = new MoveListener(inputActions, ship.AccelerateComponent);
			IMoveHandler moveHandler = new MoveHandler(moveListener, moverService.MoveWithAcceleration);
		}
	}
}
