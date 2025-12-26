using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace forest_keeper;

public sealed class Assets
{
    public Texture2D? ChristmasWinking;
    public Texture2D? Cooling;
    public Texture2D? Handshake;
    public Texture2D? Trumpet;
    public Texture2D? Wink;

    public void LoadContent(ContentManager content)
    {
        ChristmasWinking = content.Load<Texture2D>("emotichristmaswinking.png");
        Cooling = content.Load<Texture2D>("emoticooling.png");
        Handshake = content.Load<Texture2D>("emotihandshake.png");
        Trumpet = content.Load<Texture2D>("emotitrumpet.png");
        Wink = content.Load<Texture2D>("emotiwink.png");
    }

    public void UnloadContent()
    {
        ChristmasWinking?.Dispose();
        Cooling?.Dispose();
        Handshake?.Dispose();
        Trumpet?.Dispose();
        Wink?.Dispose();
    }
}