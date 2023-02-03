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
    public class UserController : ApiController
    {
        // GET: api/Estudiantes
        public string Get()
        {
            User user = new User();
            return user.ListaUsers();
        }

        // GET: api/Estudiantes/5
        public string Get(string email)
        {
            User user = new User();
            user.email = email;
            return user.ListaUsers();
        }


        // POST: api/Estudiantes
        public IHttpActionResult Post([FromBody] User user)
        {
            if (user.ConsultaUserByEmail())
            {
                return BadRequest("ya existe un estudiante con este correo!");
            }
            else
            {
                if (user.ConsultaUserByUsername())
                {
                    return BadRequest("ya existe un estudiante con este username!");
                }
                else
                {
                    string res = user.CreaUser();
                    if (res != "yes")
                    {
                        return BadRequest(res);
                    }
                    else
                    {
                        return Ok("Registrado Correctamente");
                    }
                }

            }
        }
    }
}
