using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsDBEscuela.Models
{
    [Table("Planilla")]
    public class Planilla
    {
        public int PlanillaId { get; set; }
        public int CarreraId { get; set; }
        public int MateriaId { get; set; }
        public int ProfesorId { get; set; }
        public int CursoId { get; set; }

        public DateTime Fecha { get; set; }

        #region Propiedades de Navegacion
        public List<Detalle> Detalles { get; set; } 
        public Profesor Profesor { get; set; }
        public Materia Materia { get; set; }
        public Carrera Carrera { get; set; }
        public Curso Curso { get; set; }    
        #endregion
    }
}
