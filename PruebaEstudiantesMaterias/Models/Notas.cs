using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PruebaEstudiantesMaterias.Models
{
    public class Notas
    {
        public decimal CodNota { get; set; }


        public decimal? Estudiante { get; set; }


        public decimal? Materia { get; set; }

        public decimal? Nota { get; set; }

        public string CreaNotas()
        {
            string sql = "Insert into Notas (Estudiante,Materia,Nota) values (" + Estudiante + "," + Materia + "," + Nota + ")";
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ModificaNotas()
        {
            string sql = "Update Notas Set Estudiante=" + Estudiante + ",Materia=" + Materia + ",Nota=" + Nota + " Where CodNota=" + CodNota;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string EliminaNotas()
        {
            string sql = "Delete from Notas where CodNota=" + CodNota;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string EliminaNotasByEstudiante()
        {
            string sql = "Delete from Notas where Estudiante=" + Estudiante;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string EliminaNotasByMateria()
        {
            string sql = "Delete from Notas where Materia=" + Materia;
            string res = Conexion.SqlQueryGestion(sql);
            return res;
        }

        public string ListaNotas()
        {
            string sql = "Select * from Notas for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }

        public string ConsultaNotas()
        {
            string sql = "Select N.CodNota, Est.Nombres + ' '+ Est.Apellidos Estudiante, Mat.Nombre Materia, N.Nota From Notas N Inner Join Estudiantes Est on Est.CodEstudiante=n.Estudiante Inner Join Materias Mat On Mat.CodMateria= N.Materia Where CodNota="+CodNota+" for json path";
            string dt = Conexion.SqlJson(sql);
            return dt;
        }


        public bool existeById()
        {
            string sql = "Select * from Notas where CodNota=" + CodNota + " for json path";
            bool res = Conexion.existe(sql);
            return res;
        }

        public bool existe()
        {
            string sql = "Select * from Notas where Estudiante=" + Estudiante + " And Materia="+Materia+" for json path";
            bool res = Conexion.existe(sql);
            return res;
        }
    }
}