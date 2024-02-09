using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblStudent
    {
        public int StudentId { get; set; }
        public string Personnummer { get; set; } = null!;
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public int? Klass { get; set; }

        public virtual TblKlasser? KlassNavigation { get; set; }
    }
}
