using TableApp.Table;
namespace TableAppTests;

[TestClass]
public class TableTests
{
    [TestMethod]
    public void MoveForward_TableNode_Inbounds()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 2, 2);
        // Act
        table.MoveObjectNode(true);
        // Assert
        Assert.AreEqual((2, 1), table.Result);
    }

    [TestMethod]
    public void MoveForward_TableNode_OutOfBounds()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 0, 0);
        // Act
        table.MoveObjectNode(true);
        // Assert
        Assert.AreEqual((-1, -1), table.Result);
    }

    [TestMethod]
    public void MoveBackwards_TableNode_Inbounds()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 2, 2);
        // Act
        table.MoveObjectNode(false);
        // Assert
        Assert.AreEqual((2, 3), table.Result);
    }

    [TestMethod]
    public void MoveBackwards_TableNode_OutOfBounds()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 3, 3);
        // Act
        table.MoveObjectNode(false);
        // Assert
        Assert.AreEqual((-1, -1), table.Result);
    }

    [TestMethod]
    public void RotateClockwise_TableNode()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 2, 2);
        // Act
        table.RotateObjectNode(true);
        table.MoveObjectNode(true);
        // Assert
        Assert.AreEqual((3, 2), table.Result);
    }

    [TestMethod]
    public void RotateCounterClockwise_TableNode()
    {
        // Arrange
        TableLogic table = new TableLogic(4, 4, 2, 2);
        // Act
        table.RotateObjectNode(false);
        table.MoveObjectNode(true);
        // Assert
        Assert.AreEqual((1, 2), table.Result);
    }

}