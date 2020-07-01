using System;

namespace TP03
{

    public class Pessoa
    {
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DateTime DataDeNascimento { get; set; }


        public Pessoa(string nome, string sobrenome, DateTime dataDeNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataDeNascimento = dataDeNascimento;
        }

        public static int Aniversario(DateTime dataDeNascimento)
        {
            var data = dataDeNascimento;
            var hoje = DateTime.Now;
            var previsao = Convert.ToDateTime($"{data.Day}, {data.Month}, {hoje.Year}");
            DateTime copo = Convert.ToDateTime($"{data.Day}, {data.Month}, {hoje.Year + 1}");
            int diferenca = (previsao - hoje).Days;
            if (diferenca <0)
            {
                 previsao = Convert.ToDateTime($"{data.Day}, {data.Month}, {copo.Year}");
            }
            diferenca = (previsao - hoje).Days;
            return diferenca;
        }
    }
}
