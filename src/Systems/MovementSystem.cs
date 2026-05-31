using forest_keeper.Entities;
using Microsoft.Xna.Framework;

namespace forest_keeper.Systems;

public class MovementSystem
{
    public void Update(World world, GameTime gameTime)
    {
        HandleCollisions(world);

        foreach (var (entityId, velocity) in world.velocities)
        {
            if (!world.positions.ContainsKey(entityId))
            {
                continue;
            }

            var delta = velocity * (float)gameTime.ElapsedGameTime.TotalMilliseconds / 100;
            world.positions[entityId] += delta;
        }
    }

    private void HandleCollisions(World world)
    {
        foreach (var (_, collisionEvent) in world.collisionEvents)
        {
            var hasAVelocity = world.velocities.TryGetValue(
                collisionEvent.entityA.Id,
                out var velocityA
            );
            var hasAPosition = world.positions.TryGetValue(
                collisionEvent.entityA.Id,
                out var positionA
            );
            var hasA = hasAVelocity && hasAPosition;

            var hasBVelocity = world.velocities.TryGetValue(
                collisionEvent.entityB.Id,
                out var velocityB
            );
            var hasBPosition = world.positions.TryGetValue(
                collisionEvent.entityB.Id,
                out var positionB
            );
            var hasB = hasBVelocity && hasBPosition;

            if (!hasA && !hasB)
            {
                continue;
            }

            var dynamicA = hasA && velocityA is not { X: 0, Y: 0 };
            var dynamicB = hasB && velocityB is not { X: 0, Y: 0 };
            var separation = collisionEvent.normal * collisionEvent.penetration;

            if (dynamicA && dynamicB)
            {
                world.positions[collisionEvent.entityA.Id] = positionA - separation / 2f;
                world.positions[collisionEvent.entityB.Id] = positionB + separation / 2f;
            }
            else if (dynamicA)
            {
                world.positions[collisionEvent.entityA.Id] = positionA - separation;
            }
            else if (dynamicB)
            {
                world.positions[collisionEvent.entityB.Id] = positionB + separation;
            }

            if (dynamicA)
            {
                world.velocities[collisionEvent.entityA.Id] = Vector2.Reflect(
                    velocityA,
                    -collisionEvent.normal
                );
            }

            if (dynamicB)
            {
                world.velocities[collisionEvent.entityB.Id] = Vector2.Reflect(
                    velocityB,
                    collisionEvent.normal
                );
            }
        }
    }
}
