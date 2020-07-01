using System;
using System.Collections.Generic;
using System.IO;

namespace TP03
{
    public class RepositorioDePessoasDeArquivos : RepositorioDePessoas
    {
        public override IEnumerable<Pessoa> BuscarTodasAsPessoas()
        {
            string nomeDoArquivo = ObterNomeArquivo();
            string resultado = File.ReadAllText(nomeDoArquivo);
            string[] pessoas = resultado.Split(';');
            List<Pessoa> pessoasList = new List<Pessoa>();
            for (int i = 0; i < pessoas.Length - 1; i++)
            {
                string[] dadosDaPessoa = pessoas[i].Split(',');
                string nome = dadosDaPessoa[0];
                string sobrenome = dadosDaPessoa[1];
                DateTime data = Convert.ToDateTime(dadosDaPessoa[2]);
                Pessoa pessoa = new Pessoa(nome, sobrenome, data);
                pessoasList.Add(pessoa);
            }
            //retornar a lista
            return pessoasList;
        }
        private static string ObterNomeArquivo()
        {
            var pastaDesktop = Environment.SpecialFolder.Desktop;
            string localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);
            string nomeDoArquivo = @"\dadosDasPessoas.txt";
            return localDaPastaDesktop + nomeDoArquivo;
        }
        public override IEnumerable<Pessoa> BuscarTodasAsPessoas(string nome)
        {
            string nomeDoArquivo = ObterNomeArquivo();
            string resultado = File.ReadAllText(nomeDoArquivo);
            string[] pessoas = resultado.Split(';');
            List<Pessoa> pessoasList = new List<Pessoa>();
            for (int i = 0; i < pessoas.Length - 1; i++)
            {
                string[] dadosDaPessoa = pessoas[i].Split(',');
                string nomePessoa = dadosDaPessoa[0];
                string sobrenome = dadosDaPessoa[1];
                DateTime data = Convert.ToDateTime(dadosDaPessoa[2]);
                Pessoa pessoa = new Pessoa(nomePessoa, sobrenome, data);
                if (nomePessoa.Contains(nome) || sobrenome.Contains(nome))
                {
                    pessoasList.Add(pessoa);
                };
            }
            return pessoasList;
        }

        protected override void CriarNovo(Pessoa pessoa)
        {
            string nomeDoArquivo = ObterNomeArquivo();

            string formato = $"{pessoa.Nome}, {pessoa.Sobrenome}, {pessoa.DataDeNascimento.ToString()};";

            File.AppendAllText(nomeDoArquivo, formato);
        }
    }
}