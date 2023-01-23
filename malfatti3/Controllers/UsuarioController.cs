using malfatti.Context;
using malfatti.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.Mvc;
using System.Data.Entity;

namespace malfatti.Controllers
{
    public class UsuarioController : Controller
    {

        private EFContext context = new EFContext();


        // GET: Usuario
        public ActionResult Index()
        {
            return View(context.Usuarios.OrderBy(c => c.Nome));
        }

        // GET CREATE
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {

            
            context.Usuarios.Add(usuario);
            context.SaveChanges();
            return RedirectToAction("Index");
            

        }

        //GET: Edit
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = context.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST : Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                context.Entry(usuario).State = EntityState.Modified;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }
        // GET: Usuários/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = context.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }
        // POST: Usuários/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(long id)
        {
            Usuario usuario = context.Usuarios.Find(id);
            context.Usuarios.Remove(usuario);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
    
}
