using malfatti.Models;
using malfatti.Serviço;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace malfatti.Controllers
{
     public class HomeController : Controller
    {
        private Produto produto = new Produto();
        // GET: Seguranca/Home
        public ActionResult Index()
        {
            
            return View();
        }
    }
}
