using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.ContractsComponent;
using Asteroids.Framework.Entities.ContractsEntity;

namespace Asteroids.Game.Entities.Ship
{
	public interface IShip : IEntity
	{
		IRotatable RotateComponent { get; }
		IAcceleratable AccelerateComponent { get; }
	}
}
