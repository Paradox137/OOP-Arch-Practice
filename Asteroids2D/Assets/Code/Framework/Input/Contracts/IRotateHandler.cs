﻿using System;
using System.Threading;
using Asteroids.Framework.Entities.ContractsComponent;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Asteroids.Framework.Input.Contracts
{
	public interface IRotateHandler : IUserInputHandler
	{
		void Handle(IRotatable rotatableObject, Vector3 direction, InputAction.CallbackContext context);
	}
}
