using forest_keeper.Entities;
using forest_keeper.Spawners;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;

namespace forest_keeper.Systems;

public class BallDuplicationSystem
{
    public void Update(World world, Assets assets)
    {
        foreach (var (_, collisionEvent) in world.collisionEvents)
        {
            if (
                world.balls.ContainsKey(collisionEvent.entityA.Id)
                && world.balls.ContainsKey(collisionEvent.entityB.Id)
            )
            {
                BallSpawner.CreateBall(
                    world,
                    new Vec2Int(0, world.height / 2),
                    new Vector2(15, 15),
                    assets.Trumpet
                );
            }
        }
    }
}
