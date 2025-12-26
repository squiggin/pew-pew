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
        BallSpawner.CreateBall(world, new Vec2Int(0, 0), new Vector2(1, 1), assets.ChristmasWinking);
        BallSpawner.CreateBall(world, new Vec2Int(150, 0), new Vector2(1, 1), assets.ChristmasWinking);
        BallSpawner.CreateBall(world, new Vec2Int(300, 0), new Vector2(1, 1), assets.ChristmasWinking);
        BallSpawner.CreateBall(world, new Vec2Int(1000, 600), new Vector2(-1, -1), assets.Handshake);
    }

    private static void CreateBall(World world, Vec2Int position, Vector2 velocity, Texture2D? texture,
        Vec2Int? dimensions = null)
    {
        var entity = world.CreateEntity();
        world.positions.Add(entity.Id, position);
        world.velocities.Add(entity.Id, velocity);
        world.balls.Add(entity.Id, new Ball());

        if (texture != null)
        {
            world.textures.Add(entity.Id, texture);
            world.dimensions.Add(entity.Id, dimensions ?? new Vec2Int(texture.Width, texture.Height));
        }
    }
}