using RoboSimulator.Library;
using RoboSimulator.Library.Exceptions;

namespace RoboSimulator.Tests;

public class RobotFactoryTests
{
    [Test]
    public void GenerateRandomName_UsingFixedSeed_ReturnsConstantRandomName()
    {
        // arrange
        RobotFactory factory = new RobotFactory();
        factory.fixedSeed = true;

        // act
        string result = factory.GenerateRandomName();

        // assert
        Assert.AreEqual(result, "SV752");
    }

    [Test]
    public void CreateRobot_SmallRobot_AddsToList()
    {
        // arrange
        RobotFactory factory = new RobotFactory();
        RobotType robotType = RobotType.Small;

        // act
        factory.CreateRobot(robotType);

        // assert
        Assert.AreEqual(factory.RobotList.Count, 1);
        Assert.That(factory.RobotList[0], Is.TypeOf<RobotSmall>());
    }

    [Test]
    public void CreateRobot_LargeRobot_AddsToList()
    {
        // arrange
        RobotFactory factory = new RobotFactory();
        RobotType robotType = RobotType.Large;

        // act
        factory.CreateRobot(robotType);

        // assert
        Assert.AreEqual(factory.RobotList.Count, 1);
        Assert.That(factory.RobotList[0], Is.TypeOf<RobotLarge>());
    }

    [Test]
    public void DestroyRobot_InputExistingRobotName_RemoveFromList()
    {
        // arrange
        RobotFactory factory = new RobotFactory();
        RobotSmall robot = new RobotSmall("AB123");
        factory.RobotList.Add(robot);

        // act
        factory.DestroyRobot("AB123");

        // assert
        Assert.AreEqual(factory.RobotList.Count, 0);
    }

    [Test]
    public void DestroyRobot_InputInexistingRobotName_RemoveFromList()
    {
        // arrange
        RobotFactory factory = new RobotFactory();
        RobotSmall robot = new RobotSmall("AB123");
        factory.RobotList.Add(robot);

        // act
        InexistingRobotException ex = Assert.Throws<InexistingRobotException>(() => factory.DestroyRobot("AB124"));

        // assert
        Assert.That(ex.Message, Is.EqualTo("O robô não existe!"));
        Assert.AreEqual(factory.RobotList.Count, 1);
    }
}