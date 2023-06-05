using Asteroids.Game.Factory;
using UnityEngine;

namespace Asteroids.Framework.Entities.ContractsComponent
{
	public interface IFactoryable : IGameComponent
	{
		IEntitiesFactory entitiesFactory { get; }
	}
}
