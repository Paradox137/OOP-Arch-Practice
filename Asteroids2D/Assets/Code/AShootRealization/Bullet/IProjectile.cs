using Asteroids.Framework.Entities.Contracts;
using Asteroids.ShootModule;

namespace Asteroids.AShootRealization
{
	public interface IProjectile
	{
		public IMovable MoveComponent { get; }
		
		public IEntityProvider Provider { get; }
	}
}
