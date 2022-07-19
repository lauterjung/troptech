using System.Text;
using RoboSimulator.Library.Exceptions;

namespace RoboSimulator.Library
{
    public class RobotFactory
    {
        public bool fixedSeed = false;
        private int _seed = 0;
        public List<Robot> RobotList { get; private set; }

        public RobotFactory()
        {
            RobotList = new List<Robot>();
        }
        
        public void CreateRobot(RobotType type)
        {
            switch (type)
            {
                case RobotType.Small:
                    RobotSmall smallRobot = new RobotSmall(GenerateValidName());
                    RobotList.Add(smallRobot);
                    break;
                case RobotType.Medium:
                    Console.WriteLine("Fábrica de robôs médios estragada!");
                    break;
                case RobotType.Large:
                    RobotLarge largeRobot = new RobotLarge(GenerateValidName());
                    RobotList.Add(largeRobot);
                    break;
                default:
                    throw new InvalidTypeException("Tipo de robô inválido!");
            }
        }

        public void DestroyRobot(string name)
        {
            Robot robotToDestroy = new Robot("");

            foreach (var robot in RobotList)
            {
                if (robot.Name == name)
                {
                    robotToDestroy = robot;
                    break;
                }
            }

            if (string.IsNullOrEmpty(robotToDestroy.Name))
            {
                throw new InexistingRobotException("O robô não existe!");
            }

            RobotList.Remove(robotToDestroy);
        }

        public string GenerateRandomName()
        {
            if (fixedSeed == false)
            {
                _seed = Environment.TickCount;
            }

            Random rnd = new Random(_seed);
            int firstAsciiIndex = rnd.Next(65, 91);
            char firstLetter = Convert.ToChar(firstAsciiIndex);

            int secondAsciiIndex = rnd.Next(65, 91);
            char secondLetter = Convert.ToChar(secondAsciiIndex);

            int firstNumber = rnd.Next(0, 10);
            int secondNumber = rnd.Next(0, 10);
            int thirdNumber = rnd.Next(0, 10);

            StringBuilder sb = new StringBuilder();
            sb.Append(firstLetter);
            sb.Append(secondLetter);
            sb.Append(firstNumber);
            sb.Append(secondNumber);
            sb.Append(thirdNumber);

            return sb.ToString();
        }

        public string GenerateValidName()
        {
            string name;
            do
            {
                name = GenerateRandomName();
            }
            while (RobotList.Any(x => x.Name == name));
            return name;
        }
    }
}