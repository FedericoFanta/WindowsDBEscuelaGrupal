using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Profesor")]
    public class Profesor
    {
        public int ProfesorId { get; set; } 
        public int LocalidadId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Apellido { get; set; }
        #region Propiedades de Navegacion
        public Localidad Localidad { get; set; }    
        public List<Planilla> Planillas { get; set; }
        #endregion
    }
}
