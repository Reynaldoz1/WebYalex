using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class ClienteAdminController : Controller
    {
        // GET: ClienteAdmin
        public ActionResult Index()
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.ToList());
            }
        }

        // GET: ClienteAdmin/Details/5
        public ActionResult Details(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.Where(x => x.id_cliente == id));

            }
        }

        // GET: ClienteAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteAdmin/Create
        [HttpPost]
        public ActionResult Create(clientes clientes)
        {
            try
            {
                using (DbYalex context = new DbYalex())
                {
                    context.clientes.Add(clientes);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.Where(x => x.id_cliente == id).FirstOrDefault());

            }
        }

        // POST: ClienteAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, clientes clientes)
        {
            try
            {
                using (DbYalex context = new DbYalex())
                {
                    context.Entry(clientes).State = EntityState.Modified;
                    context.SaveChanges();


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.Where(x => x.id_cliente == id).FirstOrDefault());

            }
        }

        // POST: ClienteAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbYalex context = new DbYalex())
                {
                    clientes clientes = context.clientes.Where(x => x.id_cliente == id).FirstOrDefault();
                    context.clientes.Remove(clientes);
                    context.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
