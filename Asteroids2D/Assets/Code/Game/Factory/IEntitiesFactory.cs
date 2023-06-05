using UnityEngine;

namespace Asteroids.Game.Factory
{
	public interface IEntitiesFactory
	{
		void TrySpawnEntity(GameObject gameObject);
		void SpawnEntity();
	}
}
