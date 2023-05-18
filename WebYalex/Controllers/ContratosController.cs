using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    [Autenticado]
    public class ContratosController : Controller
    {
        // GET: Contratos
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.contratos.ToList());
            }
        }

        // GET: Contratos/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.contratos.Where(x => x.id_contrato == id).FirstOrDefault());
            }
        }

        // GET: Contratos/Create
        public ActionResult Create()
        {
            using (DbModels context = new DbModels())
            {
                List<clientes> listaClientes = context.clientes.ToList();
                ViewBag.ListaClientes = new SelectList(listaClientes, "id_cliente", "nombres");



                List<alquileres> listaAlquileres = context.alquileres.ToList();
                ViewBag.listaAlquileres = listaAlquileres;


                List<vehiculo> listaVehiculos = context.vehiculo.ToList();
                ViewBag.listaVehiculos = new SelectList(listaVehiculos, "id_vehiculo", "placa");


                /*
                 * para traer solo el id
                 * List<clientes> listaClientes = context.clientes.ToList();
                ViewBag.ListaClientes = listaClientes;*/
                /*
                 * para traer solo los existentes dentro del contrato
                 List<clientes> listaClientes = context.clientes.Where(c => c.contratos.Any()).ToList();
                ViewBag.ListaClientes = listaClientes;
                 */
            }

            return View();
        }

        // POST: Contratos/Create
        [HttpPost]
        public ActionResult Create(contratos contratos)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.contratos.Add(contratos);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contratos/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                contratos contrato = context.contratos.Find(id);

                /*para traer el nombre del */
                List<clientes> listaClientes = context.clientes.ToList();
                int idClienteActual = contrato.id_cliente;
                ViewBag.ListaClientes = new SelectList(listaClientes, "id_cliente", "nombres", idClienteActual);

                List<alquileres> listaAlquileres = context.alquileres.ToList();
                ViewBag.listaAlquileres = listaAlquileres;

                List<vehiculo> listaVehiculos = context.vehiculo.ToList();
                int idVehiculoActual = contrato.id_vehiculo;
                ViewBag.listaVehiculos = new SelectList(listaVehiculos, "id_vehiculo", "placa", idVehiculoActual);

                return View(contrato);
            }
        }

        // POST: Contratos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, contratos contratos)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.Entry(contratos).State = System.Data.Entity.EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contratos/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.contratos.Where(x => x.id_contrato == id).FirstOrDefault());
            }
        }

        // POST: Contratos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    contratos contratos = context.contratos.Where(x => x.id_contrato == id).FirstOrDefault();
                    context.contratos.Remove(contratos);
                    context.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
