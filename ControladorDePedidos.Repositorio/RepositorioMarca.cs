﻿using ControladorDePedidos.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControladorDePedidos.Repositorio
{
    public class RepositorioMarca
    {
        Contexto contexto;

        public RepositorioMarca()
        {
            contexto = new Contexto();
        }

        public void Adicione(Marca marca)
        {
            contexto.Set<Marca>().Add(marca);
            contexto.SaveChanges();
        }

        public void Atualize(Marca marca)
        {
            var original = contexto.Set<Marca>().Find(marca.Codigo);
            contexto.Entry(original).CurrentValues.SetValues(marca);
            contexto.SaveChanges();
        }

        public List<Marca> Liste()
        {
            contexto = new Contexto();
            return contexto.Set<Marca>().ToList();
        }

        public void Excluir(Marca marca)
        {
            var original = contexto.Set<Marca>().Find(marca.Codigo);
            contexto.Set<Marca>().Remove(original);
            contexto.SaveChanges();
        }
    }
}
