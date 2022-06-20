namespace MiguelBusarelloLauterjungM2P3
{
    public class QuestionEmail : Email, IDisplayableEmail
    {

        private bool _isAnswered = false;
        public bool IsAnswered
        {
            get { return _isAnswered; }
            set { _isAnswered = value; }
        }
        public AnswerEmail Answer { get; set; }
        public QuestionEmail(string message) : base(message)
        {
        }
        public QuestionEmail() : base()
        {
        }

        public void Show()
        {
            Console.WriteLine($"============ Dúvida ============\n" + 
                              $"[Número de identificação]: {ID} \n" +
                              $"[Pergunta]: {Message} \n" +
                              $"[Respondido]: {(IsAnswered ? "Sim" : "Não")}");
        }
    }
}