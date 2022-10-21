using System;
using System.Collections.Generic;

namespace U3Act1AlumnadoPrueba.Models
{
    public partial class Carrera
    {
        public Carrera()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public string Clave { get; set; } = null!;
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Alumnos> Alumnos { get; set; }
    }
}
