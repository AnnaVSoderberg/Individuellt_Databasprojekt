using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblKlasser
    {
        public TblKlasser()
        {
            TblStudents = new HashSet<TblStudent>();
        }

        public int KlassId { get; set; }
        public string? KlassNamn { get; set; }

        public virtual ICollection<TblStudent> TblStudents { get; set; }
    }
}
