using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class EntregaController : Controller
    {
        [Autenticado]
        // GET: Entrega
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.entrega.ToList());
            }
        }

        // GET: Entrega/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.entrega.Where(x => x.id_entrega == id).FirstOrDefault());
            }
        }

        // GET: Entrega/Create
        public ActionResult Create()
        {
            using (DbModels context = new DbModels())
            {
                List<clientes> listaClientes = context.clientes.ToList();
                ViewBag.ListaClientes = new SelectList(listaClientes, "id_cliente", "nombres");

                List<vehiculo> listaVehiculos = context.vehiculo.ToList();
                ViewBag.listaVehiculos = new SelectList(listaVehiculos, "id_vehiculo", "placa");

                List<empleado> listaEmpleados = context.empleado.ToList();
                ViewBag.listaEmpleados = new SelectList(listaEmpleados, "id_empleado", "nombre");

                List<contratos> listaContratos = context.contratos.ToList();
                ViewBag.listaContratos = new SelectList(listaContratos, "id_contrato", "id_contrato");

            }

            return View();
        }

        // POST: Entrega/Create
        [HttpPost]
        public ActionResult Create(entrega entregas)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModels context = new DbModels())
                {
                    context.entrega.Add(entregas);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entrega/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                entrega entregas = context.entrega.Find(id);

                /*para traer el nombre del */
                List<clientes> listaClientes = context.clientes.ToList();
                int idClienteActual = entregas.id_cliente;
                ViewBag.listaClientes = new SelectList(listaClientes, "id_cliente", "nombres", idClienteActual);

                List<vehiculo> listaVehiculos = context.vehiculo.ToList();
                int idVehiculoActual = entregas.id_vehiculo;
                ViewBag.listaVehiculos = new SelectList(listaVehiculos, "id_vehiculo", "placa", idVehiculoActual);

                List<empleado> listaEmpleados = context.empleado.ToList();
                int idEmpleadoActual = entregas.id_empleado;
                ViewBag.listaEmpleados = new SelectList(listaEmpleados, "id_empleado", "nombre", idEmpleadoActual);

                List<contratos> listaContratos = context.contratos.ToList();
                int idContratoActual = entregas.id_contrato;
                ViewBag.listaContratos = new SelectList(listaContratos, "id_contrato", "id_contrato", idContratoActual);

                return View(entregas);
            }
        }

        // POST: Entrega/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, entrega entrega)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModels context = new DbModels())
                {
                    context.Entry(entrega).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Entrega/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.entrega.Where(x => x.id_entrega == id).FirstOrDefault());
            }
        }

        // POST: Entrega/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
            //TODO: Add delete logic here
                using (DbModels context = new DbModels())
                {
                    entrega entregas = context.entrega.Where(x => x.id_entrega == id).FirstOrDefault();
                    context.entrega.Remove(entregas);
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
