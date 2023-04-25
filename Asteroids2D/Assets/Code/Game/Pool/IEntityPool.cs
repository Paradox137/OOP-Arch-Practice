using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Framework.Pool
{
	public interface IEntityPool
	{
		public bool TryAddToPool(IPoolable entity);
	}
}
