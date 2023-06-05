using Asteroids.Framework.Entities.ContractsComponent;

namespace Asteroids.Game.Entities.Contracts
{
	public interface IProjectile
	{
		public IMovable MoveComponent { get; set; }
		
		//public IEntityProvider Provider { get; }
	}
}
