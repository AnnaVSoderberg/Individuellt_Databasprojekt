using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblKur
    {
        public int KurskodNy { get; set; }
        public string? Kursnamn { get; set; }
        public int? Poäng { get; set; }
        public DateTime? Kursstart { get; set; }
        public DateTime? Kursslut { get; set; }
    }
}
