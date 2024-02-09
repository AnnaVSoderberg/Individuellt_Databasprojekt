using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblTitlar
    {
        public TblTitlar()
        {
            TblPersonals = new HashSet<TblPersonal>();
        }

        public int TitelId { get; set; }
        public string? Titel { get; set; }

        public virtual ICollection<TblPersonal> TblPersonals { get; set; }
    }
}
