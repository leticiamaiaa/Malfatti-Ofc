using malfatti.DAL;
using malfatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace malfatti.Serviço
{
    public class ProdutoServico
    {
        private ProdutoDAL produtoDAL = new ProdutoDAL();
        public IQueryable<Produto> ObterProdutosClassificadosPorNome()
        {
            return produtoDAL.ObterProdutosClassificadosPorNome();
        }
        public Produto ObterProdutoPorId(long id)
        {
            return produtoDAL.ObterProdutoPorId(id);
        }
        public void GravarProduto(Produto produto)
        {
            produtoDAL.GravarProduto(produto);
        }
        public Produto EliminarProdutoPorId(long id)
        {
            return produtoDAL.EliminarProdutoPorId(id);
        }
    }
}