using System.Collections.Generic;

namespace TP03
{
    public abstract class RepositorioDePessoas
    {
        public void Salvar(Pessoa pessoa)
        {
                CriarNovo(pessoa);
        }

        protected abstract void CriarNovo(Pessoa funcionario);

        public abstract IEnumerable<Pessoa> BuscarTodasAsPessoas();
        public abstract IEnumerable<Pessoa> BuscarTodasAsPessoas(string nome);
    }
}