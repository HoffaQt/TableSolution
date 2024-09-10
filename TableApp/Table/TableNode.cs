using TableApp.Enums;
namespace TableApp.Table;

internal class TableNode(int XPosition, int YPosition)
{
    public int XPosition { get; set; } = XPosition;
    public int YPosition { get; set; } = YPosition;
    public Directions Direction { get; set; } = Directions.North;

    public Directions Rotate(bool clockwise)
    {
        return Direction = clockwise ? Direction.RotateClockwise() : Direction.RotateCounterClockwise();
    }
}
