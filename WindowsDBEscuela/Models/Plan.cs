using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Plan")]
    public class Plan
    {
        public int PlanId { get; set; }
        public int CarreraId { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [StringLength(50)]
        public string Nombre { get; set; }
        #region Propiedades de Navegacion
        public Carrera Carrera { get; set; }    
        #endregion
    }
}
