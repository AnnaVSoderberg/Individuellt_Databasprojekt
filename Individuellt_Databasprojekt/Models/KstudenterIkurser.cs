using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class KstudenterIkurser
    {
        public int? KurskodNy { get; set; }
        public int? StudentId { get; set; }

        public virtual TblKur? KurskodNyNavigation { get; set; }
        public virtual TblStudent? Student { get; set; }
    }
}
