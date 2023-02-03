using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using PruebaEstudiantesMaterias.Models;

namespace PruebaEstudiantesMaterias.Controllers
{
    public class MateriasController : ApiController
    {
        // GET: api/Materias
        public string Get()
        {
            Materias Materia = new Materias();
            return Materia.ListaMaterias();
        }

        // GET: api/Materias/5
        public string Get(int id)
        {
            Materias Materia = new Materias();
            Materia.CodMateria = id;
            return Materia.ConsultaMateria();
        }


        // POST: api/Materias
        public IHttpActionResult Post([FromBody] Materias mat)
        {
            if (mat.existeById())
            {
                return BadRequest("Esta materia ya existe!");
            }
            string res = mat.CreaMateria();
            if (res != "yes")
            {
                return BadRequest(res);
            }
            else
            {
                return Ok("Registrada Correctamente");
            }
        }

        // PUT: api/Materias/5
        public IHttpActionResult Put([FromBody] Materias mat)
        {
            if (!mat.existeById())
            {
                return BadRequest("La materia que trata de modificar, no existe!");
            }
            string res = mat.ModificaMateria();
            if (res != "yes")
            {
                return BadRequest();
            }
            else
            {
                return Ok("Modificada Correctamente");
            }
        }

        // DELETE: api/Materias/5
        public IHttpActionResult Delete(int id)
        {
            var materia = new Materias();
            var Nota = new Notas();
            materia.CodMateria = id;
            if (!materia.existeById())
            {
                return BadRequest("La materia que trata de eliminar, no existe!");
            }
            Nota.Materia = id;
            Nota.EliminaNotasByMateria();
            string res = materia.EliminaMateria();
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
