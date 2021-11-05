using System;
using System.Collections.Generic;

namespace HalloEF.Model
{
    public class Abteilung
    {
        public Guid Id { get; set; } = Guid.NewGuid();  
        public string Bezeichnung { get; set; }
        public virtual ICollection<Mitarbeiter> Mitarbeiter { get; set; } = new HashSet<Mitarbeiter>();
    }

}
