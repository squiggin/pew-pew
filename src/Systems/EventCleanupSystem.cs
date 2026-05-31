using forest_keeper.Entities;

namespace forest_keeper.Systems;

public class EventCleanupSystem
{
    public void Update(World world)
    {
        foreach (var (entityId, _) in world.collisionEvents)
        {
            world.collisionEvents.Remove(entityId);
            world.DeleteEntity(world.entities[entityId]);
        }
    }
}
