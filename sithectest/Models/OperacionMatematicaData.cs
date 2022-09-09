using System.ComponentModel.DataAnnotations;

namespace sithectest.Models
{
    /// <summary>
    /// Clase que contiene los datos necesarios para realizar la operacion matemática desde el metodo POST
    /// </summary>
    public class OperacionMatematicaData
    {
        /// <summary>
        /// Operación a realizar - Valores permitidos: SUMA, RESTA, MULTIPLICA, DIVIDE
        /// </summary>
        [Required(ErrorMessage = "Debe especificar la operación que desea ejecutar, valores permitidos SUMA, RESTA, MULTIPLICA, DIVIDE ")]
        public string operacion { get; set; }

        /// <summary>
        /// Primer número de la operación
        /// </summary>
        [Required(ErrorMessage ="Debe especificar el primer número")]
        public double numero1 { get; set; }

        /// <summary>
        /// Segundo número de la operación
        /// </summary>
        [Required(ErrorMessage = "Debe especificar el segundo número")]
        public double numero2 { get; set; }
    }
}
