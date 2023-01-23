using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using System.Collections.Generic;
using malfatti.Models.ViewModels;
using System.Net;
using System.Data;
using malfatti.Models;
using malfatti.Context;
using malfatti.Serviço;

namespace malfatti.Controllers
{
    public class ShopController : Controller
    {
        private EFContext cadcontext = new EFContext();
        private ProdutoServico produtoServico = new ProdutoServico();
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

        private EFContext efcontext = new EFContext();
        private Produto produto = new Produto();
        public ActionResult Index()
        {
            HomeClass home = new HomeClass();
            home.listaprodutos = produtoServico.ObterProdutosClassificadosPorNome();
            return View(home);
        }

        //GET: /shop/category/name
        public ActionResult Categoria(long id)
        {
            // Declare a list of ProductVM
            List<ProdutoVM> productVMList;

            using (EFContext cadcontext = new EFContext())
            {
                // Get category id
                Categoria categoriaDTO = cadcontext.Categorias.Where(x => x.CategoriaId == id).FirstOrDefault();
                long catId = categoriaDTO.CategoriaId;

                // Init the list
                productVMList = cadcontext.Produtos.ToArray().Where(x => x.CategoriaId == catId).Select(x => new ProdutoVM(x)).ToList();

                // Get category name
                ViewBag.CategoriaNome = categoriaDTO.Nome;
            }

            // Return view with list
            return View(productVMList);
        }

        // GET: /shop/product-details/name
        //[ActionName("product-details")]
        public ActionResult Details(long? id)
        {

            return ObterVisaoProdutoPorId(id);
            //// Declare the VM, DTO, and id
            ProdutoVM model;
            //Produto dto;
            //long? id;

            //using (EFContext cadcontext = new EFContext())
            //{
            //    // Check if product exists
            //    if (!cadcontext.Produtos.Any(x => x.Slug.Equals(name)))
            //    {
            //        return RedirectToAction("Index", "Shop");
            //    }

            //    // Init productDTO
            //    dto = cadcontext.Produtos.Where(x => x.Slug == name).FirstOrDefault();

            //    // Get id
            //    id = dto.ProdutoId;

            //    // Init model
            //    model = new ProdutoVM(dto);
            //}

            // Get gallery images
            model.GalleryImages = Directory.EnumerateFiles(Server.MapPath("~/Images/Uploads/Products/" + id + "/Gallery/Thumbs"))
                                                .Select(fn => Path.GetFileName(fn));

            //// Return view with model
            //return View("ProductDetails", model);
        }

        //Get: Shop/Search-Results/searchWord
        [ActionName("Search-Results")]
        public ActionResult SearchResults(string searchWord)
        {
            //initialize list of productvm
            List<ProdutoVM> lstProductVM;
            //Set defualt first page

            using (EFContext cadcontext = new EFContext())
            {
                lstProductVM = cadcontext.Produtos.ToArray()
                               .Where(x => x.Nome.ToLower().Contains(searchWord.ToLower()))
                               .Select(x => new ProdutoVM(x)).ToList();
                if (lstProductVM == null && lstProductVM.Count == 0)
                {
                    return Content("<h1>No matched results<h1>");
                }
            }
            return View(lstProductVM);
        }

    }
}
