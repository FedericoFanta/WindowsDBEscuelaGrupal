using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsDBEscuela.Models;

namespace WindowsDBEscuela.Data
{
    public class DBEscuelaContext:DbContext
    {
        public DBEscuelaContext() : base("keyDBEscuela") { }

        public DbSet<Estado> Estados { get; set; }
    }
}
