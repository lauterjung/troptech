namespace MiguelBusarelloLauterjungM2P3
{
    public class AnswerEmail : Email, IDisplayableEmail
    {
        private bool _isAnswered = false;
        public bool IsAnswered
        {
            get { return _isAnswered; }
        }
        private int _questionID;
        public int QuestionID
        {
            get { return _questionID; }
            set { _questionID = value; }
        }
        public QuestionEmail Question { get; set; }

        public AnswerEmail(string message) : base(message)
        {
        }
        public AnswerEmail() : base()
        {
        }


        public void Show()
        {
            Console.WriteLine($"============ Resposta ============\n" +
                              $"[Número de identificação do e-mail de dúvida]: {QuestionID}\n" +
                              $"[Número de identificação]: {ID} \n" +
                              $"[Dúvida]: {Question.Message} \n" +
                              $"[Resposta]: {Message}");
        }
    }
}