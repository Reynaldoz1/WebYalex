using Fluent.Infrastructure.FluentModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebYalex.Models;

namespace WebYalex.Controllers
{
    public class LoginController : Controller
    {

        Usuario user = new Usuario();


        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Registro(Usuario oUsuario)
        {
            bool usuariexist = false;

            if (oUsuario.contrasena == oUsuario.ConfirmarContra)
            {

                oUsuario.contrasena = ConvertirSha256(oUsuario.contrasena);
            }
            else
            {
                ViewData["Mensaje"] = "Las contraseñas no coinciden";
                return View();
            }

            using (SqlCommand comando = new SqlCommand("insertarCliente", Conexion.Conectar()))
            {
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.AddWithValue("@nombres", oUsuario.nombres);
                comando.Parameters.AddWithValue("@apellidos", oUsuario.apellidos);
                comando.Parameters.AddWithValue("@direccion", oUsuario.direccion);
                comando.Parameters.AddWithValue("@telefono", oUsuario.telefono);
                comando.Parameters.AddWithValue("@correo", oUsuario.correo);
                comando.Parameters.AddWithValue("@licencia", oUsuario.licencia);
                comando.Parameters.AddWithValue("@dui", oUsuario.dui);
                //comando.Parameters.AddWithValue("@estado", estado);
                comando.Parameters.AddWithValue("@contrasena", oUsuario.contrasena);


                SqlParameter usuarioExisteParam = new SqlParameter();
                usuarioExisteParam.ParameterName = "@usuarioExiste";
                usuarioExisteParam.SqlDbType = SqlDbType.Bit;
                usuarioExisteParam.Direction = ParameterDirection.Output;
                comando.Parameters.Add(usuarioExisteParam);


                comando.ExecuteNonQuery();
                usuariexist = (bool)usuarioExisteParam.Value;

            }
            if (usuariexist)
            {
                ViewData["Mensaje"] = "Usuario Ya Existente";
                return View();
                
            }
            else
            {
                ViewData["Mensaje"] = "Usuario Registrado";
                return RedirectToAction("Login", "Login");
            }



        }

        [HttpPost]
        public ActionResult Login(Usuario oUsuario)
        {
            oUsuario.contrasena = ConvertirSha256(oUsuario.contrasena);

            using (SqlCommand vali = new SqlCommand("ValidarUsuario", Conexion.Conectar()))
            {
                vali.CommandType = CommandType.StoredProcedure;
                vali.Parameters.AddWithValue("@correo", oUsuario.correo);
                vali.Parameters.AddWithValue("@contrasena", oUsuario.contrasena);
                
                oUsuario.id_cliente = Convert.ToInt32(vali.ExecuteScalar().ToString());

            }

            using (SqlCommand command = new SqlCommand("rolesyalex", Conexion.Conectar()))
            {
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@correo", oUsuario.correo);
                command.Parameters.AddWithValue("@contrasena", oUsuario.contrasena);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        oUsuario.id_cliente = Convert.ToInt32(reader["id_usuario"]);
                        oUsuario.rol = reader["rol"].ToString();
                        

                        if (oUsuario.id_cliente != 0 && !string.IsNullOrEmpty(oUsuario.rol))
                        {
                            
                            if (oUsuario.rol == "cliente")
                            {
                                Session["NombreUsuario"] = oUsuario.correo;
                                Session["RolUsuario"] = "cliente";
                                Session["UsuarioAutenticado"] = true;
                                //Session["cliente"] = oUsuario;
                                return RedirectToAction("Index", "Home");
                            }
                            else if (oUsuario.rol == "admin")
                            {
                                Session["NombreUsuario"] = oUsuario.correo;
                                Session["UsuarioAutenticado"] = true;
                                Session["RolUsuario"] = "admin";
                                //Session["admin"] = oUsuario;
                                return RedirectToAction("Index", "Admin");
                            }
                            else if (oUsuario.rol == "empleado")
                            {
                                Session["NombreUsuario"] = oUsuario.correo.ToString();
                                Session["UsuarioAutenticado"] = true;
                                Session["RolUsuario"] = "empleado";
                                //Session["empleado"] = oUsuario;
                                return RedirectToAction("Index", "Empleado");
                            }
                            else
                            {
                                //ViewData["Mensaje"] = "Rol no válido";
                                return View();
                            }
                        }
                    }
                }
            }

            ViewData["Mensaje"] = "Correo o contraseña incorrectos";
            return View();


        }

        public ActionResult CerrarSesion()
        {
            // Limpiar la sesión actual y cerrarla
            Session.Clear();
            Session.Abandon();

            // Cerrar la autenticación del usuario
            FormsAuthentication.SignOut();

            // Agregar encabezados de respuesta para evitar el almacenamiento en caché
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.SetExpires(DateTime.UtcNow.AddMinutes(-1));
            Response.Cache.SetValidUntilExpires(false);
            Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
            Response.Cache.SetNoServerCaching();
            Response.Cache.SetNoStore();


            // Redirigir a la página de inicio u otra página deseada
            return RedirectToAction("Index", "Home");
        }

        

        public static string ConvertirSha256(string texto)
        {
            //using System.Text;
            //USAR LA REFERENCIA DE "System.Security.Cryptography"

            StringBuilder Sb = new StringBuilder();
            using (SHA256 hash = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));

                foreach (byte b in result)
                    Sb.Append(b.ToString("x2"));
            }

            return Sb.ToString();
        }

    }
}