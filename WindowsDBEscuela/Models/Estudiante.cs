using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Estudiante")]
    public class Estudiante
    {
        public int EstudianteId { get; set; }
        public int LocalidadId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Telefono { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Calle { get; set; }
        public int Numero { get; set; }

        #region Propiedades de Navegacion
        public List<Evaluacion> Evaluaciones { get; set; }
        public Localidad Localidad { get; set; }
        #endregion
    }
}
