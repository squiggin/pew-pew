using forest_keeper.Components;
using forest_keeper.Components.Tags;
using forest_keeper.Entities;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace forest_keeper.Spawners;

public class BallSpawner
{
    public static void Spawn(World world, Assets assets)
    {
        BallSpawner.CreateBall(
            world,
            new Vec2Int(0, 0),
            new Vector2(15, 15),
            assets.ChristmasWinking
        );
        BallSpawner.CreateBall(
            world,
            new Vec2Int(180, 0),
            new Vector2(15, 15),
            assets.ChristmasWinking
        );
        BallSpawner.CreateBall(
            world,
            new Vec2Int(360, 0),
            new Vector2(15, 15),
            assets.ChristmasWinking
        );
        BallSpawner.CreateBall(
            world,
            new Vec2Int(800, 600),
            new Vector2(-15, -15),
            assets.Handshake
        );
        BallSpawner.CreateBall(world, new Vec2Int(300, 160), new Vector2(-10, 5), assets.Trumpet);
        BallSpawner.CreateBall(world, new Vec2Int(700, 260), new Vector2(-5, 15), assets.Cooling);
    }

    public static void CreateBall(
        World world,
        Vec2Int position,
        Vector2 velocity,
        Texture2D? texture,
        Vec2Int? dimensions = null
    )
    {
        var entity = world.CreateEntity();
        world.positions.Add(entity.Id, position);
        world.velocities.Add(entity.Id, velocity);
        world.colliders.Add(entity.Id, new Collider { type = ColliderType.Box });
        world.balls.Add(entity.Id, new Ball());

        if (texture != null)
        {
            world.textures.Add(entity.Id, texture);
            world.dimensions.Add(
                entity.Id,
                dimensions ?? new Vec2Int(texture.Width, texture.Height)
            );
        }
    }
}
