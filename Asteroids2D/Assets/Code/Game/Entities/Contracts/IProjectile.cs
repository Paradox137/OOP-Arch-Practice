using Asteroids.Framework.Entities.ContractsComponent;

namespace Asteroids.Framework.Entities.ContractsEntity
{
	public interface IProjectile
	{
		public IMovable MoveComponent { get; }
		
		//public IEntityProvider Provider { get; }
	}
}
