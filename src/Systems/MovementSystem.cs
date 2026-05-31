using forest_keeper.Entities;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;

namespace forest_keeper.Systems;

public class MovementSystem
{
    public void Update(World world, GameTime gameTime)
    {
        foreach (var (_, collisionEvent) in world.collisionEvents)
        {
            if (world.velocities.TryGetValue(collisionEvent.entityA.Id, out var velocityA) &&
                world.positions.TryGetValue(collisionEvent.entityA.Id, out var positionA))
            {
                if (velocityA is not { X: 0, Y: 0 })
                {
                    world.positions[collisionEvent.entityA.Id] =
                        positionA - Vec2Int.FromVector2(collisionEvent.normal * collisionEvent.penetration);
                    world.velocities[collisionEvent.entityA.Id] = Vector2.Reflect(velocityA, -collisionEvent.normal);
                }
            }

            if (world.velocities.TryGetValue(collisionEvent.entityB.Id, out var velocityB) &&
                world.positions.TryGetValue(collisionEvent.entityB.Id, out var positionB))
            {
                if (velocityB is not { X: 0, Y: 0 })
                {
                    world.positions[collisionEvent.entityB.Id] =
                        positionB + Vec2Int.FromVector2(collisionEvent.normal * collisionEvent.penetration);
                    world.velocities[collisionEvent.entityB.Id] = Vector2.Reflect(velocityB, collisionEvent.normal);
                }
            }
        }

        foreach (var (entityId, velocity) in world.velocities)
        {
            if (!world.positions.ContainsKey(entityId))
            {
                continue;
            }

            var delta = velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;
            world.positions[entityId] += new Vec2Int { X = (int)MathF.Round(delta.X), Y = (int)MathF.Round(delta.Y) };
        }
    }
}