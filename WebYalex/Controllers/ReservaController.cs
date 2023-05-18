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
    public class ReservaController : Controller
    {
        // GET: Reserva
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.reserva.ToList());
            }
        }

        // GET: Reserva/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.reserva.Where(x => x.id_reserva == id).FirstOrDefault());
            }
        }

        // GET: Reserva/Create
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

            }

            return View();
        }

        // POST: Reserva/Create
        [HttpPost]
        public ActionResult Create(reserva reserva)
        {
            try
            {
                // TODO: Add insert logic here
                using (DbModels context = new DbModels())
                {
                    context.reserva.Add(reserva);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                reserva reserva = context.reserva.Find(id);

                /*para traer el nombre del */
                List<clientes> listaClientes = context.clientes.ToList();
                int idClienteActual = reserva.id_cliente;
                ViewBag.ListaClientes = new SelectList(listaClientes, "id_cliente", "nombres", idClienteActual);

                List<vehiculo> listaVehiculos = context.vehiculo.ToList();
                int idVehiculoActual = reserva.id_vehiculo;
                ViewBag.listaVehiculos = new SelectList(listaVehiculos, "id_vehiculo", "placa", idVehiculoActual);

                List<empleado> listaEmpleados = context.empleado.ToList();
                int idEmpleadoActual = reserva.id_empleado;
                ViewBag.listaEmpleados = new SelectList(listaEmpleados, "id_empleado", "nombre", idEmpleadoActual);

                return View(reserva);
            }
        }

        // POST: Reserva/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, reserva reserva)
        {
            try
            {
                // TODO: Add update logic here
                using (DbModels context = new DbModels())
                {
                    context.Entry(reserva).State = EntityState.Modified;
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Reserva/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.reserva.Where(x => x.id_reserva == id).FirstOrDefault());
            }
        }

        // POST: Reserva/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (DbModels context = new DbModels())
                {
                    reserva reserva= context.reserva.Where(x => x.id_reserva == id).FirstOrDefault();
                    context.reserva.Remove(reserva);
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
