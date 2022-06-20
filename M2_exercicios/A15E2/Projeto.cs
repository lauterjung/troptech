namespace A15E2
{
    public class Projeto
    {
        public string Descricao { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public List<Participante> listaParticipantes { get; set; }

        public Projeto()
        {
            listaParticipantes = new List<Participante>();
        }
        public void InlcuirParticipante(List<string> nomesParticipante, List<Participante> listaPessoas)
        {
            foreach (string nome in nomesParticipante)
            {
                foreach (Participante participante in listaPessoas)
                {
                    if (participante.Nome == nome)
                    {
                        listaParticipantes.Add(participante);
                    }
                }
            }
        }

        public bool Validar()
        {
            if (String.IsNullOrEmpty(Descricao))
            {
                throw new ParticipanteException("Descrição é obrigatória!");
                return false;
            }
            if (listaParticipantes.Count == 0)
            {
                throw new ParticipanteException("Nenhum participante no projeto!");
                return false;
            }
            if (DataFim < DataInicio)
            {
                throw new ParticipanteException("Data de fim inferior a data de início!");
                return false;
            }
            System.Console.WriteLine("Projeto cadastrado com sucesso!");
            return true;
        }
        public string NomearParticipantes()
        {
            string result = "";
            foreach (var item in listaParticipantes)
            {
                result = result + "\n" + item.Nome;
            }
            return result;
        }
        public override string ToString()
        {
            return ($"Descrição: {Descricao}\n" +
                    $"Data de Inicio: {DataInicio.ToShortDateString}\n" +
                    $"Data de Fim: {DataFim.ToShortDateString}\n" +
                    $"Participantes:" +
                    NomearParticipantes());
        }
    }
}