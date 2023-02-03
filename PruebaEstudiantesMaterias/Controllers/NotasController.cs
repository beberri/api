using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaEstudiantesMaterias.Models;

namespace PruebaEstudiantesMaterias.Controllers
{
    public class NotasController : ApiController
    {
        // GET: api/Notas
        public string Get()
        {
            Notas Nota = new Notas();
            return Nota.ListaNotas();
        }

        // GET: api/Notas/5
        public string Get(int id)
        {
            Notas Nota = new Notas();
            Nota.CodNota = id;
            return Nota.ConsultaNotas();
        }

        // POST: api/Notas
        public IHttpActionResult Post([FromBody] Notas not)
        {
            if (not.existe())
            {
                return BadRequest("La nota para este estudiante y esta materia, ya existe!");
            }
            Materias existMat = new Materias();
            existMat.CodMateria =Convert.ToDecimal( not.Materia);
            if (!existMat.existeById())
            {
                return BadRequest("La materia no existe!");
            }
            Estudiante existEst = new Estudiante();
            existEst.CodEstudiante = Convert.ToDecimal(not.Estudiante);
            if (!existEst.existeById())
            {
                return BadRequest("El estudiante no existe!");
            }
            string res = not.CreaNotas();
            if (res != "yes")
            {
                return BadRequest(res);
            }
            else
            {
                return Ok("Registrada Correctamente");
            }
        }

        // PUT: api/Notas/5
        public IHttpActionResult Put([FromBody] Notas not)
        {
            if (!not.existeById())
            {
                return BadRequest("La nota que trata de modificar, no existe!");
            }
            string res = not.ModificaNotas();
            if (res != "yes")
            {
                return BadRequest("No se ha podido modificar esta nota, probablemente ya exista un registro con este estudiante y esta materia!");
            }
            else
            {
                return Ok("Modificada Correctamente");
            }
        }

        // DELETE: api/Notas/5
        public IHttpActionResult Delete(int id)
        {
            var Nota = new Notas();
            Nota.CodNota = id;
            if (!Nota.existeById())
            {
                return BadRequest("La nota que trata de eliminar, no existe!");
            }
            string res = Nota.EliminaNotas();
            if (res != "yes")
            {
                return BadRequest("No se ha podido completar la accion!");
            }
            else
            {
                return Ok("Eliminada Correctamente");
            }

        }
    }
}
