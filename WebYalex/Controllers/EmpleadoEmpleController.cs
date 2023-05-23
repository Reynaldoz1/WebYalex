using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class EmpleadoEmpleController : Controller
    {
        // GET: EmpleadoEmple
        public ActionResult Index()
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.ToList());
            }
        }

        // GET: EmpleadoEmple/Details/5
        public ActionResult Details(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.Where(x => x.id_empleado == id));

            }
        }

        // GET: EmpleadoEmple/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoEmple/Create
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

        // GET: EmpleadoEmple/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmpleadoEmple/Edit/5
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

        // GET: EmpleadoEmple/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmpleadoEmple/Delete/5
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
