using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaEstudiantesMaterias.Models
{
    public class Materias
    {
        public decimal CodMateria { get; set; }


        public string Nombre { get; set; }

   
        public string Curso { get; set; }

 
        public string Docente { get; set; }



        public string CreaMateria()
        {
            string sql = "Insert into Materias (Nombre,Curso,Docente) values ('" + Nombre + "','" + Curso + "','" + Docente + "')";
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ModificaMateria()
        {
            string sql = "Update Materias Set Nombre='" + Nombre + "',Curso='" + Curso + "',Docente='" + Docente + "' Where CodMateria=" + CodMateria.ToString();
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string EliminaMateria()
        {
            string sql = "Delete from Materias where CodMateria=" + CodMateria;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ListaMaterias()
        {
            string sql = "Select * from Materias for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public string ConsultaMateria()
        {
            string sql = "Select * from Materias where CodMateria='" + CodMateria + "' for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public bool existeById()
        {
            string sql = "Select * from Materias where CodMateria='" + CodMateria + "' for json path";
            bool res = Conexion.existe(sql);
            return res;
        }

    }
}