namespace Asteroids.Framework.Entities.ContractsComponent
{
	public interface IAcceleratable : IMovable
	{
		float AccelerationRatio { get; }
		float SlowdownRatio { get; }
	}
}
