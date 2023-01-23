using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using malfatti.Models;
using System.Data.Entity;
using System.Net;
using malfatti.Context;
using malfatti.Servico;
using malfatti.Serviço;
using System.IO;

namespace malfatti.Controllers
{

    public class ProdutoController : Controller
    {
        
        private ProdutoServico produto = new ProdutoServico();
        private CategoriaServico categoria = new CategoriaServico();
        private FabricanteServico fabricante = new FabricanteServico();

        //Pega os detalhes do produto de acordo com o id, serve para diminuir a redundância na hora de mostrar vz
        private ActionResult ObterVisaoProdutoPorId(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = produto.ObterProdutoPorId((long?)id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }
        // Serve para popular combobox
        private void PopularViewBag(Produto produto = null)
        {
            if (produto == null)
            {
                ViewBag.CategoriaId = new SelectList(categoria.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome");
                ViewBag.FabricanteId = new SelectList(fabricante.ObterFabricantesClassificadosPorNome(),
                "EstudioId", "Nome");
            }
            else
            {
                ViewBag.CategoriaId = new SelectList(categoria.ObterCategoriasClassificadasPorNome(),
                "CategoriaId", "Nome", produto.CategoriaId);
                ViewBag.FabricanteId = new SelectList(fabricante.ObterFabricantesClassificadosPorNome(),
                "EstudioId", "Nome", produto.FabricanteId);
            }
        }

        // Salva os produtos
        private ActionResult GravarProduto(Produto produto, HttpPostedFileBase upimg, string chkRemoverImagem)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (chkRemoverImagem != null)
                    {
                        produto.UpImg = null;
                    }
                    if (upimg != null)
                    {
                        produto.UpImgMimeType = upimg.ContentType;
                        produto.UpImg = SetUpImg(upimg);
                    }
                    produto.GravarProduto(produto);
                    return RedirectToAction("Index");
                }
                if (upimg != null)
                {
                    produto.UpImgMimeType = upimg.ContentType;
                    produto.UpImg = SetUpImg(upimg);
                    produto.NomeArquivo = upimg.FileName;
                    produto.TamanhoArquivo = upimg.ContentLength;
                }
                
                produto.GravarProduto(produto);
                PopularViewBag(produto);
                return View(produto);
            }
            catch
            {
                PopularViewBag(produto);
                return View(produto);
            }
        }

        //transfrma o arquivo recebido em um vetor de bytes
        private byte[] SetUpImg(HttpPostedFileBase upimg)
        {
            var bytesUpImg = new byte[upimg.ContentLength];
            upimg.InputStream.Read(bytesUpImg, 0, upimg.ContentLength);
            return bytesUpImg;
        }

        //contém a imagem para a exibição na visão
        public FileContentResult GetUpImg(long id)
        {
            Produto produto = produto.ObterProdutoPorId(id);
            if (produto != null)
            {
                return File(produto.UpImg, produto.UpImgMimeType);
            }
            return null;
        }

        //transferece o arquivo copiado do banco de dados para a pasta de download
        public ActionResult DownloadArquivo(long id)
        {
            Produto produto = produto.ObterProdutoPorId(id);
            FileStream fileStream = new FileStream(Server.MapPath("~/App_Data/" + produto.NomeArquivo), FileMode.Create, FileAccess.Write);
            fileStream.Write(produto.UpImg, 0, Convert.ToInt32(produto.TamanhoArquivo));
            fileStream.Close();
            return File(fileStream.Name, produto.UpImgMimeType, produto.NomeArquivo);
        }


        [Authorize(Roles = "Administradores")]
        public ActionResult Index()
        {
            return View(ProdutoServico.ObterProdutosClassificadosPorNome());
        }

        // GET: Produtos/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).
            Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // GET: Produtos/Create
        public ActionResult Create()
        {
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome),
            "CategoriaId", "Nome");
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome),
            "FabricanteId", "Nome");
            return View();
        }

        // POST: Produtos/Create
        [HttpPost]
        public ActionResult Create(Produto produto)
        {
            try
            {
                // TODO: Add insert logic here
                context.Produtos.Add(produto);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoriaId = new SelectList(context.Categorias.OrderBy(b => b.Nome), "CategoriaId",
            "Nome", produto.CategoriaId);
            ViewBag.FabricanteId = new SelectList(context.Fabricantes.OrderBy(b => b.Nome), "FabricanteId",
            "Nome", produto.FabricanteId);
            return View(produto);
        }

        // POST: Produtos/Edit/5
        [HttpPost]
        public ActionResult Edit(Produto produto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    context.Entry(produto).State = EntityState.Modified;
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(produto);
            }
            catch
            {
                return View(produto);
            }
        }

        // GET: Produtos/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Produto produto = context.Produtos.Where(p => p.ProdutoId == id).
            Include(c => c.Categoria).Include(f => f.Fabricante).First();
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        // POST: Produtos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Produto produto = context.Produtos.Find(id);
                context.Produtos.Remove(produto);
                context.SaveChanges();
                TempData["Message"] = "Produto " + produto.Nome.ToUpper() + " foi removido";
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
