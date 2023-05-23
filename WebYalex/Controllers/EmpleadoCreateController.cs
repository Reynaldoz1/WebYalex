using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class EmpleadoCreateController : Controller
    {
        // GET: EmpleadoCreate
        public ActionResult Index()
        {
            return RedirectToAction("Create");
        }

        // GET: EmpleadoCreate/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmpleadoCreate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoCreate/Create
        [HttpPost]
        public ActionResult Create(empleado empleado)
        {
            try
            {
                using (DbYalex context = new DbYalex())
                {
                    context.empleado.Add(empleado);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoCreate/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoCreate/Edit/5
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

        // GET: EmpleadoCreate/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoCreate/Delete/5
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
