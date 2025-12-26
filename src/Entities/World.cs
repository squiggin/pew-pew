using forest_keeper.Components.Tags;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace forest_keeper.Entities;

public sealed class World
{
    public HashSet<Entity> entities = [];

    public Dictionary<int, Vec2Int> positions = new();
    public Dictionary<int, Vec2Int> dimensions = new();
    public Dictionary<int, Vector2> velocities = new();
    public Dictionary<int, Texture2D> textures = new();

    public Dictionary<int, Ball> balls = new();
    public Dictionary<int, Wall> walls = new();

    private int nextEntityId = 0;
    private readonly Stack<int> freeEntityIDs = [];

    public Entity CreateEntity()
    {
        return freeEntityIDs.Count > 0
            ? new Entity { Id = freeEntityIDs.Pop() }
            : new Entity { Id = nextEntityId++ };
    }
    
    public void DeleteEntity(Entity entity)
    {
        positions.Remove(entity.Id);
        dimensions.Remove(entity.Id);
        velocities.Remove(entity.Id);
        textures.Remove(entity.Id);
        balls.Remove(entity.Id);
        walls.Remove(entity.Id);
        
        entities.Remove(entity);
        freeEntityIDs.Push(entity.Id);
    }
}