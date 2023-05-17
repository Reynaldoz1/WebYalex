using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebYalex.Models
{
    public class Usuario
    {
        public int id_cliente { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }

        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }

        public string licencia { get; set; }
        public string dui { get; set; }
        public string estado { get; set; }

        public string rol { get; set; }

        public string ConfirmarContra { get; set; }

    }
   
}