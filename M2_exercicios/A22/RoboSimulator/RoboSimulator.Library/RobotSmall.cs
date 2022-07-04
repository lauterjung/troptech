using System.Text;

namespace RoboSimulator.Library;
public class RobotSmall : Robot
{
    private RobotType _type;
    public RobotType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public RobotSmall(string name) : base(name)
    {
        _name = name;
        _xPosition = 0;
        _yPosition = 0;
        _type = RobotType.Small;
        _steps = 1;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Tipo: Pequeno";
    }
}
