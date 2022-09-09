using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace sithectest.Models
{
    /// <summary>
    /// Modelo para la tabla Humanos
    /// </summary>
    public partial class Humanos
    {
        /// <summary>
        /// Identificador del registro
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int? Id { get; set; }

        /// <summary>
        /// Nombre del humano
        /// </summary>
        [Required(ErrorMessage ="El nombre no puede ir vacio")]
        [MaxLength(250)]
        public string Nombre { get; set; }

        /// <summary>
        /// Sexo de la persona, MASCULINO ó FEMENINO
        /// </summary>
        [Required(ErrorMessage = "Debe especificar el sexo MASCULINO ó FEMENINO")]
        public string Sexo { get; set; }

        /// <summary>
        /// Edad en años
        /// </summary>
        [Required(ErrorMessage ="Debe especificar la edad en años")]
        [Range(0,120)]
        public int? Edad { get; set; }

        /// <summary>
        /// Altura en metros y centimetros en formato decimal
        /// </summary>
        public decimal? Altura { get; set; }

        /// <summary>
        /// Peso en kilogramos
        /// </summary>
        public decimal? Peso { get; set; }
    }
}
