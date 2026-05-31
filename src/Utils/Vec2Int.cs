using Microsoft.Xna.Framework;

namespace forest_keeper.Utils;

public struct Vec2Int
{
        public int X;
        public int Y;

        public Vec2Int(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vec2Int FromVector2(Vector2 vec)
        {
            return new Vec2Int((int)vec.X, (int)vec.Y);
        }

        public static Vec2Int operator +(Vec2Int a, Vec2Int b)
        {
            return new Vec2Int(a.X + b.X, a.Y + b.Y);
        }
        
        public static Vec2Int operator -(Vec2Int a, Vec2Int b)
        {
            return new Vec2Int(a.X - b.X, a.Y - b.Y);
        }

        public override string ToString() => $"({X}, {Y})";
}