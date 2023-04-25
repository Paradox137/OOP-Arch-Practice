using System;

namespace Asteroids.Framework.Entities.ContractsEntity
{
	public interface IPoolable
	{
		public event Predicate<IPoolable> onNeedToPool; 
		public void Activate();
		public void Deactivate();
	}
}
