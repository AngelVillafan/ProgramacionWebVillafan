using System;
using System.Collections.Generic;

namespace U3Act1AlumnadoPrueba.Models
{
    public partial class Alumnos
    {
        public string Control { get; set; } = null!;
        public string Paterno { get; set; } = null!;
        public string Materno { get; set; } = null!;
        public string Nombre { get; set; } = null!;
        public byte Sexo { get; set; }
        public string Idcarrera { get; set; } = null!;
        public uint Entrada { get; set; }

        public virtual Carrera IdcarreraNavigation { get; set; } = null!;
    }
}
