using forest_keeper.Components;
using forest_keeper.Components.Tags;
using forest_keeper.Entities;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;

namespace forest_keeper.Spawners;

public class WallSpawner
{
    
    public static void Spawn(World world)
    {
        WallSpawner.CreateWall(world, new Vec2Int(-1, 0), new Vec2Int(1, world.height));
        WallSpawner.CreateWall(world, new Vec2Int(0, 0), new Vec2Int(world.width, 1));
        WallSpawner.CreateWall(world, new Vec2Int(world.width, 0), new Vec2Int(1, world.height));
        WallSpawner.CreateWall(world, new Vec2Int(0, world.height), new Vec2Int(world.width, 1));
    }

    private static void CreateWall(World world, Vec2Int position, Vec2Int dimensions)
    {
        var entity = world.CreateEntity();
        world.positions.Add(entity.Id, position);
        world.velocities.Add(entity.Id, new Vector2(0, 0));
        world.colliders.Add(entity.Id, new Collider { type = ColliderType.Box });
        world.walls.Add(entity.Id, new Wall());
        world.dimensions.Add(entity.Id, dimensions);
    }
}