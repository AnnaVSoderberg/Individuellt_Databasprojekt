using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class VWspersonalTitel
    {
        public int PersonalId { get; set; }
        public string? Förnamn { get; set; }
        public string? Efternamn { get; set; }
        public string? Titel { get; set; }
    }
}
