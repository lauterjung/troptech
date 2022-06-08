Expression expression = new(Console.ReadLine());

System.Console.WriteLine(expression.Evaluate());

class Expression
{
    private readonly int _left;
    private readonly int _right;
    // Recebemos o supertipo
    private readonly Operator _operator;

    public Expression(string value)
    {
        var values = value.Split(" ");

        _left = int.Parse(values[0]);
        // Polimorfismo de inclusão
        _operator = OperatorFactory.Create(values[1]);
        _right = int.Parse(values[2]);
    }

    public bool Evaluate()
        => _operator.Evaluate(_left, _right);
}

class OperatorFactory
{
    public static Operator Create(string @operator)
        => @operator switch
        {
            ">" => new GreaterThan(),
            "<" => new LessThan(),
            "==" => new EqualTo(),
            _ => throw new ArgumentException($"{@operator} é um operador não suportado.")
        };
}

class LessThan : Operator
{
    public override bool Evaluate(int left, int right)
        => left < right;
}

class GreaterThan : Operator
{
    public override bool Evaluate(int left, int right)
        => left > right;
}

class EqualTo : Operator
{
    public override bool Evaluate(int left, int right)
        => left == right;
}

abstract class Operator
{
    public abstract bool Evaluate(int left, int right);
}