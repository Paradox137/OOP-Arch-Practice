using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Storage
{
	public interface IEntityStorage
	{
		void Add(IEntity entity);

		void Remove(IEntity entity);
	}
}
