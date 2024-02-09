using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class TblBetyg
    {
        public int BetygId { get; set; }
        public string? Betyg { get; set; }
        public int? Betygpoäng { get; set; }
    }
}
