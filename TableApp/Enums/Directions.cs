namespace TableApp.Enums;

public enum Directions
{
    North,
    East,
    South,
    West,
}

public static class DirectionsExtensions
{
    public static Directions RotateClockwise(this Directions direction) => direction switch
    {
        Directions.North => Directions.East,
        Directions.East => Directions.South,
        Directions.South => Directions.West,
        Directions.West => Directions.North,
        _ => Directions.North
    };

    public static Directions RotateCounterClockwise(this Directions direction) => direction switch
    {
        Directions.North => Directions.West,
        Directions.West => Directions.South,
        Directions.South => Directions.East,
        Directions.East => Directions.North,
        _ => Directions.North
    };

    public static (int, int) ForwardMovementValue(this Directions direction) => direction switch
    {
        Directions.North => (0, -1),
        Directions.East => (1, 0),
        Directions.South => (0, 1),
        Directions.West => (-1, 0),
        _ => (0, 0)
    };

    public static (int, int) BackwardMovementValue(this Directions direction) => direction switch
    {
        Directions.North => (0, 1),
        Directions.East => (-1, 0),
        Directions.South => (0, -1),
        Directions.West => (1, 0),
        _ => (0, 0)
    };
}


