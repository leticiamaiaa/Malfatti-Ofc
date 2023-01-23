using malfatti.DAL;
using malfatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malfatti.Servico
{
    
    public class CategoriaServico
    {
        private CategoriaDAL categoriaDAL = new CategoriaDAL();
        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return categoriaDAL.ObterCategoriasClassificadasPorNome();
        }
        public Categoria ObterCategoriaPorId(long id)
        {
            return categoriaDAL.ObterCategoriaPorId(id);
        }
        public void GravarCategoria(Categoria categoria)
        {
            categoriaDAL.GravarCategoria(categoria);
        }
        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = categoriaDAL.ObterCategoriaPorId(id);
            categoriaDAL.EliminarCategoriaPorId(id);
            return categoria;
        }
    }
}