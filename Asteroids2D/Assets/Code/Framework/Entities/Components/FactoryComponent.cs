using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Game.Factory;
using UnityEngine;

namespace Asteroids.Framework.Entities.Components
{
	public struct FactoryComponent : IFactoryable
	{
		public IEntitiesFactory entitiesFactory { get; }
		
		public FactoryComponent(IEntitiesFactory entitiesFactory)
		{
			this.entitiesFactory = entitiesFactory;
		}

		public void TryCreateObject()
		{
			entitiesFactory.SpawnEntity();
		}
	}
}
