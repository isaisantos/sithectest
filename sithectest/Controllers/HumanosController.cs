using Microsoft.AspNetCore.Mvc;
using sithectest.Models;
using System.Collections.Generic;
using System.Linq;

namespace sithectest.Controllers
{
    /// <summary>
    /// Controler para el CRUD de la tabla Humanos
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class HumanosController : Controller
    {
        /// <summary>
        /// Retorna la lista de todos los registros de la tabla Humanos
        /// </summary>
        /// <returns>Retorna un valor JSON con el estatus del proceso y un result la lista de registros de la tabla Humanos, 
        /// el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/humanos</example>
        [HttpGet]
        public IActionResult Get()
        {
            List<Humanos> lstHumanos = new List<Humanos>();

            using (var db = new sithec_testContext())
            {
                lstHumanos =  db.Humanos.ToList();
            }
            
            return  Json(new { status = true, result = lstHumanos });
        }

        /// <summary>
        /// Retorna un registro de la tabla Humanos dado un ID 
        /// </summary>
        /// <param name="id">ID del humano a buscar</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y un result con el registro encontrado, 
        /// el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/humanos/1</example>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            Humanos oHumano = new Humanos();

            using (var db = new sithec_testContext())
            {
                oHumano = db.Humanos.Find(id);

                if (oHumano == null)
                {
                    return Json(new { status = false, result = string.Format("El id {0} no existe", id) });
                }
            }

            return Json(new { status = true, result = oHumano });
        }

        /// <summary>
        /// Insertar un nuevo registro en la tabla Humanos
        /// </summary>
        /// <param name="humano">Objeto JASON de tipo Humanos con las propiedades Id, Nombre, Sexo, Edad, Altura, Peso. 
        /// Ejemplo: { "Id":5, "Nombre":"Jose Lopez", "Sexo":"Masculino", "Edad":55, "Altura":1.75, "Peso": 72 }</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y un result con el mensaje de exito o fracaso de la inserción, el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/humanos</example>
        [HttpPost]
        public IActionResult Post(Humanos humano)
        {
            using (var db = new sithec_testContext())
            {
                try
                {
                    humano.Id = null;

                    db.Humanos.Add(humano);
                    db.SaveChanges();
                    return Json(new { status = true, result = "Guardado exitoso" });
                }
                catch (System.Exception ex)
                {
                    return Json(new { status = false, result = string.Format("Error al guardar - ERROR: {0}", ex.Message) });
                }
            }
        }

        /// <summary>
        /// Modifica un registro de la tabla Humanos
        /// </summary>
        /// <param name="humanos">Objeto JASON de tipo Humanos con las propiedades Id, Nombre, Sexo, Edad, Altura, Peso. 
        /// Ejemplo: { "Id":5, "Nombre":"Jose Lopez", "Sexo":"Masculino", "Edad":55, "Altura":1.75, "Peso": 72 }</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y un result con el mensaje de exito o fracaso de la modificación, el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/humanos</example>
        [HttpPut]
        public IActionResult Put(Humanos humanos)
        {
            using (var db = new sithec_testContext())
            {
                var oHumanoOld = db.Humanos.Find(humanos.Id);

                if (oHumanoOld != null)
                {
                    try
                    {
                        db.Entry(oHumanoOld).CurrentValues.SetValues(humanos);
                        db.SaveChanges();

                        return Json(new { status = true, result = "Guardado exitoso" });
                    }
                    catch (System.Exception ex)
                    {
                        return Json(new { status = false, result = string.Format("Error al guardar - ERROR: {0}", ex.Message) });
                    }
                }
                else  // El ID del registro que se desea modificar no existe
                {
                    return Json(new { status = false, result = string.Format("Error al guardar, el id {0} no existe", humanos.Id) });
                }
            }
        }


        /// <summary>
        /// Elimina un registro de la tabla Humanos
        /// </summary>
        /// <param name="id">Identificador del registro a borrar</param>
        /// <returns>Retorna un valor JSON con el estatus del proceso y un result con el mensaje de exito o fracaso del borrado, el estatus puede ser true o false</returns>
        /// <example>https://localhost:44388/humanos/10</example>
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            using (var db = new sithec_testContext())
            {
                var oHumano = db.Humanos.Find(id);

                if (oHumano != null)
                {
                    try
                    {
                        db.Humanos.Remove(oHumano);
                        db.SaveChanges();

                        return Json(new { status = true, result = "Borrado exitoso" });
                    }
                    catch (System.Exception ex)
                    {
                        return Json(new { status = false, result = string.Format("Error al eliminar - ERROR: {0}", ex.Message) });
                    }
                }
                else
                {
                    return Json(new { status = false, result = string.Format("Error al borrar, el id {0} no existe", id) });
                }
            }
        }
    }
}
