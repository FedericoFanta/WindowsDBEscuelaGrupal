using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Evaluacion")]
    public class Evaluacion
    {
        public int EvaluacionId { get; set; }
        public int TipoId { get; set; }
        public int EstudianteId { get; set; }
        public int DetalleId { get; set; }
        public decimal Nota { get; set; }

        #region Propiedades de Navegacion
        public Detalle Detalle { get; set; }
        public Tipo tipo { get; set; }
        public Estudiante Estudiante { get; set; }
        #endregion
    }
}
