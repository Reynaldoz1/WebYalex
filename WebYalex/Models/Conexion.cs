using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebYalex.Models
{
    public class Conexion
    {
        public static SqlConnection Conectar()
        {
            SqlConnection cn = new SqlConnection("SERVER=Danir;DATABASE=yalexrenta;Integrated security=true");

            cn.Open();

            return cn;
        }
    }
}