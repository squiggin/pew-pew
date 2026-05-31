using forest_keeper.Entities;

namespace forest_keeper.Systems;

public class EventCleanupSystem
{
    public void Update(World world)
    {
        foreach (var entityId in world.collisionEvents.Keys.ToList())
        {
            world.collisionEvents.Remove(entityId);

            if (world.entities.TryGetValue(entityId, out var entity))
            {
                world.DeleteEntity(entity);
            }
        }
    }
}
