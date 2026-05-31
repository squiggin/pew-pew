using System.Collections.Immutable;
using forest_keeper.Components.Events;
using forest_keeper.Entities;
using Microsoft.Xna.Framework;

namespace forest_keeper.Systems;

public class CollisionDetectionSystem
{
    public void Update(World world)
    {
        var colliderEntities = world.colliders.Keys.ToImmutableList();
        for (int i = 0; i < colliderEntities.Count; i++)
        {
            var entityIdA = colliderEntities[i];
            if (!(world.positions.TryGetValue(entityIdA, out var positionA) &&
                  world.dimensions.TryGetValue(entityIdA, out var dimensionsA)))
            {
                continue;
            }

            for (int j = i+1; j < colliderEntities.Count; j++)
            {
                var entityIdB = colliderEntities[j];
                
                if (entityIdA == entityIdB ||
                    !(world.positions.TryGetValue(entityIdB, out var positionB) &&
                      world.dimensions.TryGetValue(entityIdB, out var dimensionsB))
                   )
                {
                    continue;
                }

                CheckBoxBoxCollision(new Rectangle(positionA.X, positionA.Y, dimensionsA.X, dimensionsA.Y),
                    new Rectangle(positionB.X, positionB.Y, dimensionsB.X, dimensionsB.Y), out var isCollision,
                    out var normal, out var penetration);

                if (isCollision && normal.HasValue && penetration.HasValue)
                {
                    var collisionEventEntity = world.CreateEntity();
                    world.collisionEvents.Add(
                        collisionEventEntity.Id,
                        new CollisionEvent
                        {
                            entityA = world.entities[entityIdA], entityB = world.entities[entityIdB],
                            normal = normal.Value, penetration = penetration.Value
                        }
                    );
                }
            }
        }
    }

    private static void CheckBoxBoxCollision(Rectangle boxA, Rectangle boxB, out bool isCollision, out Vector2? normal,
        out float? penetration)
    {
        if (!boxA.Intersects(boxB))
        {
            isCollision = false;
            normal = null;
            penetration = null;
            return;
        }

        isCollision = true;

        float penetrationX;
        Vector2 normalX;
        float penetrationY;
        Vector2 normalY;

        if (Math.Abs(boxA.Right - boxB.Left) <= Math.Abs(-boxA.Left + boxB.Right))
        {
            penetrationX = boxA.Right - boxB.Left;
            normalX = new Vector2(1, 0);
        }
        else
        {
            penetrationX = -boxA.Left + boxB.Right;
            normalX = new Vector2(-1, 0);
        }

        if (Math.Abs(boxA.Bottom - boxB.Top) <= Math.Abs(-boxA.Top + boxB.Bottom))
        {
            penetrationY = boxA.Bottom - boxB.Top;
            normalY = new Vector2(0, 1);
        }
        else
        {
            penetrationY = -boxA.Top + boxB.Bottom;
            normalY = new Vector2(0, -1);
        }

        if (Math.Abs(penetrationX) <= Math.Abs(penetrationY))
        {
            penetration = penetrationX;
            normal = normalX;
        }
        else
        {
            penetration = penetrationY;
            normal = normalY;
        }
    }
}