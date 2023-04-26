using System;
using Asteroids.Game.Spawner;

namespace Asteroids.Framework.Entities.ContractsEntity
{
	public interface IPoolable
	{
		public event Predicate<IPoolable> onNeedToPool; 
		public void Activate(IEntitiesSpawner spawner);

		public event Action<IEntity> onActivate;
		public event Action<IEntity> onDeactivate;
		public void Deactivate();
	}
}
