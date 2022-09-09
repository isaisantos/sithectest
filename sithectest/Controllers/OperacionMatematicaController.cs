using Microsoft.AspNetCore.Mvc;
using sithectest.Models;
using System;

namespace sithectest.Controllers
{
    /// <summary>
    /// Controler que permite realizar una operación matematica del tipo suma, resta, multiplicación y división con dos números
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class OperacionMatematicaController : Controller
    {
        /// <summary>
        /// Realiza una operación matemática entre dos número y retorna el resultado 
        /// </summary>
        /// <param name="Datos">Objeto de tipo OperacionMatematicaData que contiene la operación a realizar y los números utilizados en el cálculo en formato JSON
        /// ejemlo: { "operacion":"DIVIDE","numero1":324,"numero2":33 }</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y su resultado, el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/operacionmatematica</example>
        /// 
        [HttpPost]
        public IActionResult Post(OperacionMatematicaData Datos)
        {
            return Calcula(Datos.operacion, Datos.numero1, Datos.numero2);
        }

        /// <summary>
        /// Realiza una operación matemática entre dos números y retorna el resultado 
        /// </summary>
        /// <param name="operacion">Operación a realizar: valores válidos: "SUMA", "RESTA", "MULTIPLICA", "DIVIDE" </param>
        /// <param name="numero1">Primer número</param>
        /// <param name="numero2">Segundo número</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y su resultado, el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/operacionmatematica/multiplica/554/11</example>
        [HttpGet("{operacion}/{numero1}/{numero2}")]    
        public IActionResult Get(string operacion, double numero1, double numero2)
        {
            return Calcula(operacion, numero1, numero2);
        }

        /// <summary>
        /// Reliza el cálculo matematico
        /// </summary>
        /// <param name="operacion">Operación a realizar: valores válidos: "SUMA", "RESTA", "MULTIPLICA", "DIVIDE"</param>
        /// <param name="numero1">Primero número</param>
        /// <param name="numero2">Segundo número</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y su resultado, el estatus puede ser true o false</returns>
        private IActionResult Calcula(string operacion, double numero1, double numero2)
        {
            double resultado = 0;

            try
            {
                switch (operacion.ToUpper())
                {
                    case "SUMA":
                        resultado = numero1 + numero2;
                        break;
                    case "RESTA":
                        resultado = numero1 - numero2;
                        break;
                    case "MULTIPLICA":
                        resultado = numero1 * numero2;
                        break;
                    case "DIVIDE":
                        if (numero2 == 0)
                            return Json(new { status = false, result = "Error: No es posible dividir entre 0" });
                        else
                            resultado = numero1 / numero2;
                        break;
                    default:
                        return Json(new { status = false, result = string.Format("Error: Operación {0} no disponible, solo se permiten las operaciones, SUMA, RESTA, MULTIPLICA Y DIVIDE.", operacion.ToUpper()) });
                }
            }
            catch (Exception ex)
            {
                return Json(new { status = false, result = string.Format("Error:{0}", ex.Message) });
            }

            return Json(new { status = true, result = resultado });
        }
    }
}
