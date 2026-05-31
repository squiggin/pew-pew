using forest_keeper.Entities;
using Microsoft.Xna.Framework;

namespace forest_keeper.Components.Events;

public struct CollisionEvent
{
    public Entity entityA;
    public Entity entityB;
    public Vector2 normal;
    public float penetration;

    public override string ToString()
    {
        return $"{{Entities: {entityA.Id}, {entityB.Id}, " +
               $"Normal: {normal.ToString()}, " +
               $"Penetration: {penetration.ToString()}";
    }
}