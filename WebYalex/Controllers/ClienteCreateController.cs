using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class ClienteCreateController : Controller
    {
        // GET: ClienteCreate
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: ClienteCreate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ClienteCreate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClienteCreate/Create
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

        // GET: ClienteCreate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ClienteCreate/Edit/5
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

        // GET: ClienteCreate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteCreate/Delete/5
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
