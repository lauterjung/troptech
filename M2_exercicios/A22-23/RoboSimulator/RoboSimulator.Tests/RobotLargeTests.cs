namespace RoboSimulator.Tests;
using RoboSimulator.Library;

public class RobotLargeTests
{
    [Test]
    public void AdvanceRobot_Advance3Times_PosX0PosY3()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.AdvanceRobot();
        robot.AdvanceRobot();
        robot.AdvanceRobot();

        // assert
        Assert.AreEqual(robot.XPosition, 0);
        Assert.AreEqual(robot.YPosition, 9);
    }

    [Test]
    public void TurnRight_1Time_FacingEast()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.TurnRight();

        // assert
        Assert.AreEqual(robot.Direction, Directions.East);
    }

    [Test]
    public void TurnRight_4Time_FacingEast()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.TurnRight();
        robot.TurnRight();
        robot.TurnRight();
        robot.TurnRight();

        // assert
        Assert.AreEqual(robot.Direction, Directions.North);
    }

    [Test]
    public void TurnLeft_1Time_FacingEast()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.TurnLeft();

        // assert
        Assert.AreEqual(robot.Direction, Directions.West);
    }

    [Test]
    public void TurnLeft_4Time_FacingEast()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.TurnLeft();
        robot.TurnLeft();
        robot.TurnLeft();
        robot.TurnLeft();

        // assert
        Assert.AreEqual(robot.Direction, Directions.North);
    }

    [Test]
    public void Move_InstructionsAAA_PosX0PosY9()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.Move("AAA");

        // assert
        Assert.AreEqual(robot.XPosition, 0);
        Assert.AreEqual(robot.YPosition, 9);
        Assert.AreEqual(robot.Direction, Directions.North);
    }

    [Test]
    public void Move_InstructionsDAAEAE_PosX6PosY3()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        robot.Move("DAAEAE");

        // assert
        Assert.AreEqual(robot.XPosition, 6);
        Assert.AreEqual(robot.YPosition, 3);
        Assert.AreEqual(robot.Direction, Directions.West);
    }

    [Test]
    public void MyCoordinates_Initial_PosX0PosY0()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "0 0");
    }

    [Test]
    public void MyCoordinates_CoordinatesDAAEAE_PosX6PosY3()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");
        robot.XPosition = 6;
        robot.YPosition = 3;

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "6 3");
    }

    [Test]
    public void MyCoordinates_CoordinatesEAADAD_PosXMinus6PosY3()
    {
        // arrange
        RobotLarge robot = new RobotLarge("AB123");
        robot.XPosition = -6;
        robot.YPosition = 3;

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "-6 3");
    }
}