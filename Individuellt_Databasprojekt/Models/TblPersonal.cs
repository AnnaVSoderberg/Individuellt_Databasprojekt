using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblPersonal
    {
        public int PersonalId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public int? Titel { get; set; }
        public decimal? Lön { get; set; }
        public DateTime? StartDatum { get; set; }

        public virtual TblTitlar? TitelNavigation { get; set; }
    }
}
