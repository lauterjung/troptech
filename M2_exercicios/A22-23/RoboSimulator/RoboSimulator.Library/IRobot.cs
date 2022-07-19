namespace RoboSimulator.Library
{
    public interface IRobot
    {
        public string MyCoordinates();
        public string MyName();
        public void Move(string sequence);
    }
}