namespace RoboSimulator.Tests;
using RoboSimulator.Library;

public class RobotSmallTests
{
    [Test]
    public void AdvanceRobot_Advance3Times_PosX0PosY3()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.AdvanceRobot();
        robot.AdvanceRobot();
        robot.AdvanceRobot();

        // assert
        Assert.AreEqual(robot.XPosition, 0);
        Assert.AreEqual(robot.YPosition, 3);
    }

    [Test]
    public void TurnRight_1Time_FacingEast()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.TurnRight();

        // assert
        Assert.AreEqual(robot.Direction, Directions.East);
    }

    [Test]
    public void TurnRight_4Time_FacingEast()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

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
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.TurnLeft();

        // assert
        Assert.AreEqual(robot.Direction, Directions.West);
    }

    [Test]
    public void TurnLeft_4Time_FacingEast()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.TurnLeft();
        robot.TurnLeft();
        robot.TurnLeft();
        robot.TurnLeft();

        // assert
        Assert.AreEqual(robot.Direction, Directions.North);
    }

    [Test]
    public void Move_InstructionsAAA_PosX0PosY3()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.Move("AAA");

        // assert
        Assert.AreEqual(robot.XPosition, 0);
        Assert.AreEqual(robot.YPosition, 3);
        Assert.AreEqual(robot.Direction, Directions.North);
    }

    [Test]
    public void Move_InstructionsDAAEAE_PosX2PosY1()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        robot.Move("DAAEAE");

        // assert
        Assert.AreEqual(robot.XPosition, 2);
        Assert.AreEqual(robot.YPosition, 1);
        Assert.AreEqual(robot.Direction, Directions.West);
    }

    [Test]
    public void MyCoordinates_Initial_PosX0PosY0()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "0 0");
    }

    [Test]
    public void MyCoordinates_CoordinatesDAAEAE_PosX2PosY1()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");
        robot.XPosition = 2;
        robot.YPosition = 1;

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "2 1");
    }

    [Test]
    public void MyCoordinates_CoordinatesEAADAD_PosXMinus2PosY1()
    {
        // arrange
        RobotSmall robot = new RobotSmall("AB123");
        robot.XPosition = -2;
        robot.YPosition = 1;

        // act
        var result = robot.MyCoordinates();

        // assert
        Assert.AreEqual(result, "-2 1");
    }
}