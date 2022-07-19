using System.Text;
using RoboSimulator.Library.Exceptions;

namespace RoboSimulator.Library;
public class Robot : IRobot
{
    public int _xPosition;
    public int XPosition
    {
        get { return _xPosition; }
        set { _xPosition = value; }
    }

    public int _yPosition;
    public int YPosition
    {
        get { return _yPosition; }
        set { _yPosition = value; }
    }

    public string _name;
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public int _steps;
    public int Steps
    {
        get { return _steps; }
    }

    public Directions _direction;
    public Directions Direction
    {
        get { return _direction; }
        set { _direction = value; }
    }

    public Robot(string name)
    {
        _name = name;
        _xPosition = 0;
        _yPosition = 0;
        _direction = Directions.North;
    }

    public string MyCoordinates()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(_xPosition);
        sb.Append(" ");
        sb.Append(_yPosition);
        return sb.ToString();
    }

    public string MyName()
    {
        return _name;
    }

    public void Move(string sequence)
    {
        foreach (var item in sequence)
        {
            switch (item)
            {
                case 'A':
                    AdvanceRobot();
                    break;
                case 'D':
                    TurnRight();
                    break;
                case 'E':
                    TurnLeft();
                    break;
                default:
                    throw new MoveRobotException("Comando não entendido!");
                    break;
            }
        }
    }

    public void AdvanceRobot()
    {
        switch (_direction)
        {
            case Directions.North:
                _yPosition += _steps;
                break;
            case Directions.East:
                _xPosition += _steps;
                break;
            case Directions.South:
                _yPosition -= _steps;
                break;
            case Directions.West:
                _xPosition -= _steps;
                break;
        }
    }

    public void TurnRight()
    {
        if ((int)_direction == 3)
        {
            _direction = Directions.North;
        }
        else
        {
            _direction += 1;
        }
    }

    public void TurnLeft()
    {
        if ((int)_direction == 0)
        {
            _direction = Directions.West;
        }
        else
        {
            _direction -= 1;
        }
    }

    public override string ToString()
    {
        return $"Nome: {Name} | Direção: {Direction} | Posição X: {XPosition} | Posição Y: {YPosition}";
    }
}
