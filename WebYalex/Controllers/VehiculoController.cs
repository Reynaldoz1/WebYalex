using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    [Autenticado]
    public class VehiculoController : Controller
    {
        // GET: Vehiculo
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.vehiculo.ToList());
            }
        }

        // GET: Vehiculo/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.vehiculo.Where(x => x.id_vehiculo == id).FirstOrDefault());
            }
        }

        // GET: Vehiculo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Vehiculo/Create
        [HttpPost]
        public ActionResult Create(vehiculo vehiculo)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.vehiculo.Add(vehiculo);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.vehiculo.Where(x => x.id_vehiculo == id).FirstOrDefault());
            }
        }

        // POST: Vehiculo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, vehiculo vehiculo)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(vehiculo).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Vehiculo/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.vehiculo.Where(x => x.id_vehiculo == id).FirstOrDefault());
            }
        }

        // POST: Vehiculo/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    vehiculo vehiculo = context.vehiculo.Where(x => x.id_vehiculo == id).FirstOrDefault();
                    context.vehiculo.Remove(vehiculo);
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
