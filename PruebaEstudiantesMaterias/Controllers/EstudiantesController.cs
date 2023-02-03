using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PruebaEstudiantesMaterias.Models;

namespace PruebaEstudiantesMaterias.Controllers
{
    public class EstudiantesController : ApiController
    {
        // GET: api/Estudiantes
        public string Get()
        {
            Estudiante estudiantes = new Estudiante();
            return estudiantes.ListaEstudiantes();
        }

        // GET: api/Estudiantes/5
        public string Get(string id)
        {
            Estudiante estudiantes = new Estudiante();
            estudiantes.Documento_Identidad = id;
            return estudiantes.ConsultaEstudiante();
        }


        // POST: api/Estudiantes
        public IHttpActionResult Post([FromBody] Estudiante est)
        {
            if (est.existe())
            {
                return BadRequest("Este estudiante ya existe!");
            }
            string res = est.CreaEstudiante();
            if (res != "yes")
            {
                return BadRequest(res);
            }
            else
            {
                return Ok("Registrado Correctamente");
            }
        }

        // PUT: api/Estudiantes/5
        public IHttpActionResult Put([FromBody] Estudiante est)
        {
            if (!est.existeById())
            {
                return BadRequest("El estudiante que trata de modificar, no existe!");
            }
            string res = est.ModificaEstudiante();
            if (res != "yes")
            {
                return BadRequest("No se ha podido completar el registro, es probable que exista este numero de documento con otro estudiante!");
            }
            else
            {
                return Ok("Modificado Correctamente");
            }
        }

        // DELETE: api/Estudiantes/5
        public IHttpActionResult Delete(int id)
        {
            var estudiantes = new Estudiante();
            var Nota = new Notas();
            estudiantes.CodEstudiante = id;
            if (!estudiantes.existeById())
            {
                return BadRequest("El estudiante que trata de eliminar, no existe!");
            }
            Nota.Estudiante= id;
            Nota.EliminaNotasByEstudiante();
            string res = estudiantes.EliminaEstudiante();
            if (res != "yes")
            {
                return BadRequest("No se ha podido completar la accion!");
            }
            else
            {
                return Ok("Eliminado Correctamente");
            }
            
        }
    }
}
