using forest_keeper.Entities;
using forest_keeper.Utils;
using Microsoft.Xna.Framework;

namespace forest_keeper.Systems;

public class MovementSystem
{
    public void Update(World world, GameTime gameTime)
    {
        foreach (var (entityId, velocity) in world.velocities)
        {
            if (!world.positions.ContainsKey(entityId))
            {
                continue;
            }

            var delta = velocity * (float) gameTime.ElapsedGameTime.TotalMilliseconds / 10;
            world.positions[entityId] += new Vec2Int { X = (int)MathF.Round(delta.X), Y = (int)MathF.Round(delta.Y) };
        }
    }
}