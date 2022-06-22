namespace ControlePonto.ClassLibs
{
public class Funcionario
{
    public string Nome { get; set; }
    public string Funcao { get; set; }
    public int Idade { get; set; }

    public Funcionario()
    {

    }
    public bool Validar()
    {
        if (String.IsNullOrEmpty(Nome))
        {
            throw new FuncionarioException("Campo nome é obrigatório!");
            return false;
        }
        if (String.IsNullOrEmpty(Funcao))
        {
            throw new FuncionarioException("Campo função é obrigatório!");
            return false;
        }
        if (Idade < 18)
        {
            throw new FuncionarioException("Idade deve ser superior a 18 anos!");
            return false;
        }
        return true;
    }

    public override string ToString()
    {
        return $"Nome: {Nome}\n" +
               $"Funcao: {Funcao}\n" +
               $"Idade: {Idade}\n";
    }

}

}