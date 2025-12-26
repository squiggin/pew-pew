namespace forest_keeper.Entities;

public struct Entity : IEquatable<Entity>
{
    public int Id;

    public bool Equals(Entity other)
    {
        return Id == other.Id;
    }

    public override bool Equals(object? obj)
    {
        return obj is Entity other && Equals(other);
    }

    public override int GetHashCode()
    {
        return Id;
    }
}