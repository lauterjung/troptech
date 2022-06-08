namespace A10E3
{
    public class EmailMaterial : Email
    {
        public EmailMaterial(string nome, string texto) : base(nome, texto)
        {
        }

        public override void Template()
        {
            Console.WriteLine(("========== Material ==========\n" +
                               $"Professor: {Nome}\n" +
                               $"Conteúdo: {Texto}"));
        }
    }
}