using System;
using System.Collections.Generic;

namespace U2Act2.Models
{
    public partial class Partidopolitico
    {
        public Partidopolitico()
        {
            Presidente = new HashSet<Presidente>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; } = null!;

        public virtual ICollection<Presidente> Presidente { get; set; }
    }
}
