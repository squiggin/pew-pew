using forest_keeper.Components;
using forest_keeper.Components.Events;
using forest_keeper.Components.Tags;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace forest_keeper.Entities;

public sealed class World
{
    public int width;
    public int height;

    public Dictionary<int, Entity> entities = new();

    public Dictionary<int, Vec2Int> positions = new();
    public Dictionary<int, Vec2Int> dimensions = new();
    public Dictionary<int, Texture2D> textures = new();
    public Dictionary<int, Vector2> velocities = new();
    public Dictionary<int, Collider> colliders = new();
    public Dictionary<int, CollisionEvent> collisionEvents = new();

    public Dictionary<int, Ball> balls = new();
    public Dictionary<int, Wall> walls = new();

    private int nextEntityId = 0;
    private readonly Stack<int> freeEntityIDs = [];

    public World(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public Entity CreateEntity()
    {
        var entity =
            freeEntityIDs.Count > 0
                ? new Entity { Id = freeEntityIDs.Pop() }
                : new Entity { Id = nextEntityId++ };
        entities.Add(entity.Id, entity);
        return entity;
    }

    public void DeleteEntity(Entity entity)
    {
        positions.Remove(entity.Id);
        dimensions.Remove(entity.Id);
        velocities.Remove(entity.Id);
        textures.Remove(entity.Id);
        balls.Remove(entity.Id);
        walls.Remove(entity.Id);

        entities.Remove(entity.Id);
        freeEntityIDs.Push(entity.Id);
    }
}
