using System;
using Asteroids.Framework.Entities;

namespace Asteroids.AShootRealization
{
	public interface IPoolable
	{
		public event Predicate<IPoolable> onNeedToPool; 
		public void Activate();
		public void Deactivate();
		
	}
}
