using Asteroids.Game.Entities.Bullet;
using Asteroids.Game.Pool;
using Asteroids.Game.Spawner;
using Asteroids.Game.Storage;

namespace Asteroids.Game.Factory
{
	public class BulletFactory : EntitiesFactory<BulletWeapon, Bullet>
	{
		public BulletFactory(IEntityPool entityPool, IEntityStorage entityStorage, BulletWeapon spawner) : base(entityPool, entityStorage, spawner) { }

		public override void SpawnEntity()
		{
			Bullet entity = spawner.Spawn<Bullet>(ref counter);
			
			SubscribeEntity(ref entity);
			
			entity.Init();
		}
	}
}
