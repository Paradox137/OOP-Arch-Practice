using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Storage
{
	public interface IEntitiesStorage
	{
		void Add(IEntity entity);

		void Remove(IEntity entity);
	}
}
