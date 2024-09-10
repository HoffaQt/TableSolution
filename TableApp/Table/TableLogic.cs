using TableApp.Enums;
namespace TableApp.Table;

public class TableLogic
{
    private readonly TableNode?[,] TableArray;
    private TableNode ObjectNode;
    private bool IsOutOfBounds { get; set; }
    public (int, int) Result { get; set; }

    public TableLogic(int columns, int rows, int startXPosition, int startYPosition)
    {
        TableArray = new TableNode[columns, rows];
        ObjectNode = new TableNode(startXPosition, startYPosition);
        TableArray[startXPosition, startYPosition] = ObjectNode;
        IsOutOfBounds = false;
        Result = (startXPosition, startYPosition);
    }

    private static (int, int) GetMovement(int currentX, int currentY, Directions direction, bool forwards)
    {
        (int moveX, int moveY) = forwards ? direction.ForwardMovementValue() : direction.BackwardMovementValue();

        if (moveX >= 0)
            moveX = currentX + moveX;
        else if (moveX < 0)
            moveX = currentX - Math.Abs(moveX);

        if (moveY >= 0)
            moveY = currentY + moveY;
        else if (moveY < 0)
            moveY = currentY - Math.Abs(moveY);

        return (moveX, moveY);
    }

    public bool MoveObjectNode(bool forwards)
    {
        (int moveToX, int moveToY) = GetMovement(ObjectNode.XPosition, ObjectNode.YPosition, ObjectNode.Direction, forwards);

        if (moveToX == -1 || moveToX >= TableArray.GetLength(0) || moveToY == -1 || moveToY >= TableArray.GetLength(1))
        {
            Result = (-1, -1);
            IsOutOfBounds = true;
            return false;
        }
        else if (!IsOutOfBounds)
        {
            TableArray[ObjectNode.XPosition, ObjectNode.YPosition] = null;
            TableArray[moveToX, moveToY] = ObjectNode;

            ObjectNode.XPosition = moveToX;
            ObjectNode.YPosition = moveToY;
            Result = (moveToX, moveToY);
        }
        return true;
    }

    public void RotateObjectNode(bool clockwise)
    {
        ObjectNode.Rotate(clockwise);
    }

}
