using System;
using System.Collections.Generic;

namespace BoletimSolution.Library
{
    public class Boletim
    {
        private string _nomeAluno;
        public string NomeAluno
        {
            get { return _nomeAluno; }
            set { _nomeAluno = value; }
        }

        private double[] _notas;
        public double[] Notas
        {
            get { return _notas; }
            set { _notas = value; }
        }

        public Boletim(string nomeAluno)
        {
            _nomeAluno = nomeAluno;
            _notas = new double[4] { double.NaN, double.NaN, double.NaN, double.NaN };
        }

        public Boletim(string nomeAluno, double[] notas)
        {
            _nomeAluno = nomeAluno;
            _notas = notas;
        }

        public double InformarNota(double nota, int bimestre)
        {
            Notas[bimestre - 1] = nota;
            return Notas[bimestre - 1];
        }
        public List<double> MostrarMenorQueSete()
        {
            List<double> ListaNotasMenorQueSete = new List<double>();
            foreach (double item in Notas)
            {
                if (double.IsNaN(item))
                {
                    continue;
                }

                if (item < 7)
                {
                    ListaNotasMenorQueSete.Add(item);
                }
            }
            return ListaNotasMenorQueSete;
        }

        public double CalcularMediaParcial()
        {
            double somaNotasParciais = 0;
            int contadorNotas = 0;
            foreach (var item in Notas)
            {
                if (!double.IsNaN(item))
                {
                    somaNotasParciais += item;
                    contadorNotas++;
                }
            }
            double MediaParcial = somaNotasParciais / contadorNotas;
            return MediaParcial;
        }

        public double CalcularMediaFinal()
        {
            // if(any(NaN)) => throw exception
            double somaNotasParciais = 0;

            foreach (var item in Notas)
            {
                somaNotasParciais += item;
            }

            return somaNotasParciais / Notas.Length;
        }
    }
}