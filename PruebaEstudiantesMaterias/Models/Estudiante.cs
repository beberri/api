using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaEstudiantesMaterias.Models
{
    public class Estudiante
    {
        public decimal CodEstudiante { get; set; }


        public string Documento_Identidad { get; set; }


        public string Nombres { get; set; }


        public string Apellidos { get; set; }

        public short? Edad { get; set; }


        public string Telefono { get; set; }


        public string Direccion { get; set; }

        public string CreaEstudiante() {
            string sql = "Insert into Estudiantes (Documento_Identidad,Nombres,Apellidos,Edad,Telefono,Direccion) values ('" + Documento_Identidad + "','" + Nombres + "','" + Apellidos + "','" + Edad.ToString() + "','" + Telefono + "','" + Direccion + "')";
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ModificaEstudiante()
        {
            string sql = "Update Estudiantes Set Documento_Identidad='"+Documento_Identidad+"',Nombres='"+Nombres+"',Apellidos='"+Apellidos+"',Edad="+Edad.ToString()+",Telefono='"+Telefono+"',Direccion='"+Direccion+"' Where CodEstudiante="+CodEstudiante.ToString();
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string EliminaEstudiante()
        {
            string sql = "Delete from Estudiantes where CodEstudiante=" + CodEstudiante;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ListaEstudiantes()
        {
            string sql = "Select * from estudiantes for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public string ConsultaEstudiante()
        {
            string sql = "Select * from estudiantes where Documento_Identidad='" + Documento_Identidad + "' for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public bool existe()
        {
            string sql = "Select * from estudiantes where Documento_Identidad='"+ Documento_Identidad + "' for json path";
            bool res   = Conexion.existe(sql);
            return res;
        }

        public bool existeById()
        {
            string sql = "Select * from estudiantes where CodEstudiante='" + CodEstudiante + "' for json path";
            bool res = Conexion.existe(sql);
            return res;
        }
    }
}