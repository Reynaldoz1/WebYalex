using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class ClienteEmpleController : Controller
    {
        // GET: ClienteEmple
        public ActionResult Index()
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.ToList());
            }
        }

        // GET: ClienteEmple/Details/5
        public ActionResult Details(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.clientes.Where(x => x.id_cliente == id));

            }
        }

        // GET: ClienteEmple/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteEmple/Create
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

        // GET: ClienteEmple/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteEmple/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ClienteEmple/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteEmple/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
