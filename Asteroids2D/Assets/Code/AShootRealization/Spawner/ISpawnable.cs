using System;
using UnityEngine;

namespace Asteroids.AShootRealization
{
	public interface ISpawnable
	{
		event Func<int, int> ad;
		bool isReady { get; }
		
		Transform spawnParent { get; }

		Vector3 GetSpawnPosition();
		Quaternion GetRotation();
	}
}
