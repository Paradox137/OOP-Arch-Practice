using System.Collections.Generic;
using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Storage
{
	public class EntityStorage : IEntityStorage
	{
		private List<IEntity> activeEntities;
		
		public EntityStorage()
		{
			activeEntities = new List<IEntity>();
		}

		public void Add(IEntity entity)
		{
			activeEntities.Add(entity);
		}
		public void Remove(IEntity entity)
		{
			if (activeEntities.Contains(entity))
			{
				activeEntities.Remove(entity);
			}
		}
	}
}
