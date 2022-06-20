namespace A15E2
{
    public class Participante
    {
        public string Nome { get; set; }
        public string Funcao { get; set; }

        public Participante()
        {

        }
        public bool Validar()
        {
            if (String.IsNullOrEmpty(Nome) || Nome.Length < 3)
            {
                throw new ParticipanteException("Campo nome é obrigatório e deve conter 3 caractéres!");
                return false;
            }
            if (String.IsNullOrEmpty(Funcao) || Funcao.Length < 3)
            {
                throw new ParticipanteException("Campo função é obrigatório e deve conter 3 caractéres!");
                return false;
            }
            return true;
        }
        public override string ToString()
        {
            return ($"Nome: {Nome}\n" +
                    $"Função: {Funcao}");
        }
    }
}