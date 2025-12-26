using forest_keeper.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace forest_keeper.Systems.Rendering;

public class RenderSystem
{
    public void Update(World world, SpriteBatch batch)
    {
        batch.Begin();

        foreach (var (entityId, position) in world.positions)
        {
            if (!world.textures.TryGetValue(entityId, out var texture) ||
                !world.dimensions.TryGetValue(entityId, out var dimensions))
            {
                continue;
            }

            var destination = new Rectangle(position.X, position.Y, dimensions.X, dimensions.Y);
            batch.Draw(texture, destination, null, Color.White);
        }

        batch.End();
    }
}