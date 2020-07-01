using System;
using System.Linq;

namespace TP03
{
    public static class Apresentacao
    {
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }

        public static void MenuPrincipal()
        {
            EscreverNaTela("Menu do sistema:");
            EscreverNaTela("Selecione uma operação");
            EscreverNaTela("1 - Adicionar nova pessoa");
            EscreverNaTela("2 - pesquisar pessoa pelo nome ou parte do nome");
            EscreverNaTela("3 - Sair");

            char operacao = Console.ReadLine().ToCharArray()[0];

            switch (operacao)
            {
                case '1': CadastrarPessoa(); break;
                case '2': ConsultarPessoa(); break;
                default: EscreverNaTela("Opção inexistente"); break;
            }
        }

        private static void CadastrarPessoa()
        {
            LimparTela();

            EscreverNaTela("Entre com o Nome:");
            string nome = Console.ReadLine();

            EscreverNaTela("Entre com o Sobrenome:");
            string sobrenome = Console.ReadLine();

            EscreverNaTela("Entre com a data de nascimento no formato (dd/MM/yyyy):");
            var dataDeNascimento = DateTime.Parse(Console.ReadLine());

            var pessoa = new Pessoa(nome, sobrenome, dataDeNascimento);

            BancoDeDados.Salvar(pessoa);

            EscreverNaTela("Cadastrado com sucesso!");
            EscreverNaTela("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            LimparTela();

            MenuPrincipal();
        }

        private static void LimparTela() //Limpar o console
        {
            Console.Clear();
        }

        private static void ConsultarPessoa()
        {
            LimparTela();
            ExibirOpcoesDeFiltro();
        }
        private static void ExibirOpcoesDeFiltro()
        {
            EscreverNaTela("Escolha uma opção de filtro");
            EscreverNaTela("1 - Consultar pelo nome ou parte do nome");
            EscreverNaTela("2 - Exibir todos os funcionários");
            string tipoDeConsulta = Console.ReadLine();
            switch (tipoDeConsulta)
            {
                case "1":
                    ConsultarPeloNome();
                    break;

                case "2":
                    ExibirTodosOsFuncionarios();
                    break;
                default:
                    EscreverNaTela("Consulta incorreta");
                    ExibirOpcoesDeFiltro();
                    break;
            }
        }
        private static void ConsultarPeloNome()
        {
            EscreverNaTela("Entre com o nome ou parte do nome da pessoa");
            string nome = Console.ReadLine();
            var pessoasEncontradas = BancoDeDados.BuscarTodasAsPessoas(nome);
            int quantidadeDePessoasEncontradas = pessoasEncontradas.Count();
            if (quantidadeDePessoasEncontradas > 0)
            {
                EscreverNaTela("Pessoas encontradas! digite o numero correspondente da pessoa que quer conferir o aniversário:");
                int i = 0;
                foreach (var pessoa in pessoasEncontradas)
                {
                    
                    EscreverNaTela($"{i} - Nome: {pessoa.Nome} Sobrenome: {pessoa.Sobrenome} Nascido em: {pessoa.DataDeNascimento}");
                    i++;
                }
                int selecaoDeNome = int.Parse(Console.ReadLine());
                int x = 0;
                    foreach (var pessoa in pessoasEncontradas)
                    {
                        if (selecaoDeNome == x)
                        {
                            Console.WriteLine($"{x} - Nome: {pessoa.Nome} Sobrenome: {pessoa.Sobrenome} Nascido em: {pessoa.DataDeNascimento}");
                            Console.WriteLine($"{Pessoa.Aniversario(pessoa.DataDeNascimento)} dias");
                        };

                        x++;
                        
                    };

            }
            else
            {
                EscreverNaTela("Nenhuma pessoa encontrada para o nome: " + nome);
            }
            MenuPrincipal();
        }
        private static void ExibirTodosOsFuncionarios()
        {
            foreach (var pessoa in BancoDeDados.BuscarTodasAsPessoas())
            {
                EscreverNaTela($"Nome: {pessoa.Nome} Sobrenome: {pessoa.Sobrenome} Nascido em: {pessoa.DataDeNascimento}");
            }
            EscreverNaTela("Pressione qualquer tecla para continuar");
            Console.ReadKey();
            LimparTela();
            MenuPrincipal();
        }

        public static RepositorioDePessoas BancoDeDados
        {
            get
            { 
                return new RepositorioDePessoasDeArquivos();
            }
        }
    }
}
