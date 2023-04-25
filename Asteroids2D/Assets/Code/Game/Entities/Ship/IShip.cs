using Asteroids.Framework.Entities;
using Asteroids.Framework.Entities.Contracts;

namespace Asteroids.Game.Entities.Ship
{
	public interface IShip : IEntity
	{
		IRotatable RotateComponent { get; }
		IAcceleratable AccelerateComponent { get; }
	}
}
