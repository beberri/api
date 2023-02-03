using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaEstudiantesMaterias.Models
{
    public class User
    {



        public string username { get; set; }


        public string email { get; set; }


        public string pass { get; set; }

        public string CreaUser()
        {


            string sql = "Insert into persona (username,email,pass) values ('" + username + "','" + email + "','" + pass + "')";
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }



        public string ListaUsers()
        {
            string sql = "Select * from persona for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public bool ConsultaUserByEmail()
        {
            string sql = "Select * from persona where email='" + email + "' for json path";
            bool res = Conexion.existe(sql);
            return res;
        }

        public bool ConsultaUserByUsername()
        {
            string sql = "Select * from persona where username='" + username + "' for json path";
            bool res = Conexion.existe(sql);
            return res;
        }


    }
}