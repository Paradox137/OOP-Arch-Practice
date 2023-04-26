using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Pool
{
	public interface IEntityPool
	{
		public bool TryAddEntity(IPoolable entity);

		public IPoolable TryGetEntity();
	}
}
