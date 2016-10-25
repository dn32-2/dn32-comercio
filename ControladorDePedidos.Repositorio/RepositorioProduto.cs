using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioProduto
    {
        Contexto contexto;

        public RepositorioProduto()
        {
            contexto = new Contexto();
        }

        public void Adicione(Produto produto)
        {
            var marcaDoBanco = contexto.Set<Marca>().Find(produto.Marca.Codigo);
            produto.Marca = marcaDoBanco;

            contexto.Set<Produto>().Add(produto);
            contexto.SaveChanges();
        }

        public void Atualize(Produto produto)
        {
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(produto);
            contexto.SaveChanges();
        }

        public List<Produto> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<Produto>().ToList();
        }

        public void Excluir(Produto produto)
        {
            var original = contexto.Set<Produto>().Find(produto.Codigo);
            contexto.Set<Produto>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
