using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class EmpleadoAdminController : Controller
    {
        // GET: EmpleadoAdmin
        public ActionResult Index()
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.ToList());
            }
        }

        // GET: EmpleadoAdmin/Details/5
        public ActionResult Details(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.Where(x => x.id_empleado == id));

            }
        }

        // GET: EmpleadoAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpleadoAdmin/Create
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

        // GET: EmpleadoAdmin/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.Where(x => x.id_empleado == id).FirstOrDefault());

            }
        }

        // POST: EmpleadoAdmin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, empleado empleado)
        {
            try
            {
                using (DbYalex context = new DbYalex())
                {
                    context.Entry(empleado).State = EntityState.Modified;
                    context.SaveChanges();


                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: EmpleadoAdmin/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbYalex context = new DbYalex())
            {

                return View(context.empleado.Where(x => x.id_empleado == id).FirstOrDefault());

            }
        }

        // POST: EmpleadoAdmin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbYalex context = new DbYalex())
                {
                    empleado empleado = context.empleado.Where(x => x.id_empleado == id).FirstOrDefault();
                    context.empleado.Remove(empleado);
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
