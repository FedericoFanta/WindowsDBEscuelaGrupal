using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Materia")]
    public class Materia
    {
        public int MateriaId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }

        #region Propiedades de Navegacion
        public List<Planilla> Planillas { get; set; }   
        #endregion
    }
}
