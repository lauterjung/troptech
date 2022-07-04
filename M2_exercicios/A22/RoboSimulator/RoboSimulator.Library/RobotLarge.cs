using System.Text;

namespace RoboSimulator.Library;
public class RobotLarge : Robot
{
    private RobotType _type;
    public RobotType Type
    {
        get { return _type; }
        set { _type = value; }
    }

    public RobotLarge(string name) : base(name)
    {
        _name = name;
        _xPosition = 0;
        _yPosition = 0;
        _type = RobotType.Large;
        _steps = 3;
    }

    public override string ToString()
    {
        return $"{base.ToString()} | Tipo: Grande";
    }
}
