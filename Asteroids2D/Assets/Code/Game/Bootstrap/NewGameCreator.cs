using System.Collections.Generic;
using System.Threading;
using Asteroids.AShootRealization;
using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.Components;
using Asteroids.Framework.Entities.Contracts;
using Asteroids.Framework.Input;
using Asteroids.Framework.Input.Contracts;
using Asteroids.Framework.Service.Contracts;
using Asteroids.Game.Entities.Ship;
using Asteroids.Game.Input;
using Asteroids.Game.Input.Handlers;
using Asteroids.Game.Input.Listeners;
using Asteroids.Game.Services;
using UnityEngine;

namespace Asteroids.Game.Bootstrap
{
	class A
	{
		public string name;

		public A(string name)
		{
			this.name = name;
		}
	}
	public class NewGameCreator : MonoBehaviour
	{
		[SerializeField] GameObject shipGameObject;
		
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
			
			IRotatable rotateComponent = new RotateComponent(shipGameObject.transform, 200);
			IAcceleratable moveComponent = new AccelerationComponent(shipGameObject.transform, 5f, 0.85f, 0.6f);
			IShip ship = new Ship(rotateComponent, moveComponent, shipGameObject);
			
			IMoverWithAccelerationService moverService = new AccelerationMover();
			IRotatorService rotator = new Rotator();
			
			RotateListener rotateListener = new RotateListener(inputActions, ship.RotateComponent);
			IRotateHandler rotateHandler = new RotateHandler(rotateListener);
			MoveListener moveListener = new MoveListener(inputActions, ship.AccelerateComponent);
			IMoveHandler moveHandler = new MoveHandler(moveListener);

			
			moveHandler.Moved += moverService.MoveWithAcceleration;
			rotateHandler.Rotated += rotator.Rotate;
		}
	}
}
