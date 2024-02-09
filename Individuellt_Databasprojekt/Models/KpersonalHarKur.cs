using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class KpersonalHarKur
    {
        public int? PersonalId { get; set; }
        public int? KurskodNy { get; set; }

        public virtual TblKur? KurskodNyNavigation { get; set; }
        public virtual TblPersonal? Personal { get; set; }
    }
}
