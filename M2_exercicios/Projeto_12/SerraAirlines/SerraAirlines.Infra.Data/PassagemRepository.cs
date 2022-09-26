using System;
using System.Collections.Generic;
using SerraAirlines.Domain;
using SerraAirlines.Domain.Exceptions;
using SerraAirlines.Infra.Data.DAO;

namespace SerraAirlines.Infra.Data
{
    public class PassagemRepository : IPassagemRepository
    {
        private PassagemDAO _passagemDAO = new PassagemDAO();

        public void Adicionar(Passagem passagem)
        {
            _passagemDAO.Adicionar(passagem);
        }

        public void Atualizar(Passagem passagem)
        {
            Passagem passagemBuscada = _passagemDAO.BuscarPorId(passagem.Id);

            if (passagemBuscada is null)
            {
                throw new PassagemNaoEncontrada();
            }
            
            _passagemDAO.Atualizar(passagemBuscada);
        }

        public List<Passagem> BuscarPorData(DateTime dataHora)
        {
            List<Passagem> listaPassagens = _passagemDAO.BuscarPorData(dataHora);

            if (listaPassagens.Count == 0)
            {
                throw new NenhumaPassagemRegistrada();
            }

            return listaPassagens;
        }

        public Passagem BuscarPorId(int id)
        {
            Passagem passagem = _passagemDAO.BuscarPorId((int)id);

            if (passagem is null)
            {
                throw new PassagemNaoEncontrada();
            }

            return passagem;
        }

        public List<Passagem> BuscarPorOrigem(string origem)
        {
            List<Passagem> listaPassagens = _passagemDAO.BuscarPorOrigem(origem);

            if (listaPassagens.Count == 0)
            {
                throw new NenhumaPassagemRegistrada();
            }

            return listaPassagens;
        }

        public List<Passagem> BuscarPorDestino(string destino)
        {
            List<Passagem> listaPassagens = _passagemDAO.BuscarPorDestino(destino);

            if (listaPassagens.Count == 0)
            {
                throw new NenhumaPassagemRegistrada();
            }

            return listaPassagens;
        }

        public List<Passagem> BuscarTodas()
        {
            List<Passagem> listaPassagens = _passagemDAO.BuscarTodas();

            if (listaPassagens.Count == 0)
            {
                throw new NenhumaPassagemRegistrada();
            }

            return listaPassagens;
        }
    }
}