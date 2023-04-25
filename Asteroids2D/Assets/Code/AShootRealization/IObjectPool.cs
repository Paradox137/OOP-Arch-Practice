using Asteroids.Framework.Entities;

namespace Asteroids.AShootRealization
{
	public interface IObjectPool
	{
		public bool TryAddToPool(IPoolable entity);
	}
}
