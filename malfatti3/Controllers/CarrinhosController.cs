using malfatti.Carrinho.Models;
using malfatti.Models;
using System;
using System.Collections.Generic;
using System.Web.Mvc;
using malfatti.DAL;
using malfatti.Servico;
using malfatti.Serviço;
using malfatti.Context;

namespace malfatti.Areas.Carrinho.Controllers
{
    public class CarrinhosController : Controller
    {
        private ProdutoServico produtoServico = new ProdutoServico();
        // GET: Carrinho/Carrinhos
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            IEnumerable<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as IEnumerable<ItemCarrinho>;
            if (carrinho == null)
            {
                carrinho = new List<ItemCarrinho>();
                HttpContext.Session["carrinho"] = carrinho;
            }
            return View(carrinho);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public PartialViewResult AddProduto(FormCollection collection)
        {
            List<ItemCarrinho> carrinho = HttpContext.Session["carrinho"] as List<ItemCarrinho>;
            var produto = produtoServico.ObterProdutoPorId(Convert.ToInt32(collection.Get("idproduto")));
            var itemCarrinho = new ItemCarrinho();
            

            itemCarrinho.Produto = produto;
            itemCarrinho.Quantidade = 1;
            itemCarrinho.ValorUnitario = produto.Preco;

            carrinho.Add(itemCarrinho);
            HttpContext.Session["carrinho"] = carrinho;
            return PartialView("_ItemCarrinho", carrinho);
        }
    }
}