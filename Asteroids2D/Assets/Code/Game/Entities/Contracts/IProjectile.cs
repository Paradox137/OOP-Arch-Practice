using Asteroids.Framework.Entities.ContractsComponent;

namespace Asteroids.Game.Entities.Contracts
{
	public interface IProjectile
	{
		public IMovable MoveComponent { get; }
		
		//public IEntityProvider Provider { get; }
	}
}
