namespace A10E3
{
    public class EmailDuvida : Email
    {
        public EmailDuvida(string nome, string texto) : base(nome, texto)
        {
        }

        public override void Template()
        {
            Console.WriteLine(("========== Dúvida ==========\n" +
                               $"Aluno: {Nome}\n" +
                               $"Pergunta: {Texto}"));
        }
    }
}