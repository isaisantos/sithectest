using Microsoft.AspNetCore.Mvc;
using sithectest.Models;
using System.Collections.Generic;

namespace sithectest.Controllers
{
    /// <summary>
    /// Retorna una lista de elementos de tipo Humanos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HumanoListaController : Controller
    {
        /// <summary>
        /// Retorna una lista de objetos de tipo Humanos con los siguientes valores (Id, Nombre, Sexo, Edad, Altura, Peso)
        /// sin conectarse a la base de datos
        /// </summary>
        /// <returns>Lista de objetos de tipo HumanoData en JSON</returns>
        /// <example>https://localhost:44388/humanolista</example>
        [HttpGet]
        public IActionResult Get()
        {
            List<Humanos> lstHumano = new List<Humanos>();

            lstHumano.Add(new Humanos() { Id = 1, Nombre = "Pedro Lopez", Sexo = "MASCULINO", Edad = 25, Altura = 1.75M, Peso = 75 });
            lstHumano.Add(new Humanos() { Id = 2, Nombre = "María Perez Santiago", Sexo = "FEMENINO", Edad = 64, Altura = 1.55M, Peso = 62 });
            lstHumano.Add(new Humanos() { Id = 3, Nombre = "Efraín Gutierrez Martinez", Sexo = "MASCULINO", Edad = 40, Altura = 1.65M, Peso = 82 });
            lstHumano.Add(new Humanos() { Id = 4, Nombre = "Epifania Velazco Ramirez", Sexo = "FEMENINO", Edad = 32, Altura = 1.62M, Peso = 71 });
            lstHumano.Add(new Humanos() { Id = 5, Nombre = "José Pérez Pérez", Sexo = "MASCULINO", Edad = 76, Altura = 1.63M, Peso = 63 });

            return Json(new { status = true, result = lstHumano });
        }
    }
}
