using System;
using System.Collections.Generic;

namespace Individuellt_Databasprojekt.Models
{
    public partial class KsattaBetyg
    {
        public int? BetygId { get; set; }
        public DateTime? Betygsdatum { get; set; }
        public int? PersonalId { get; set; }
        public int? KurskodNy { get; set; }
        public int? StudentId { get; set; }

        public virtual TblBetyg? Betyg { get; set; }
        public virtual TblKur? KurskodNyNavigation { get; set; }
        public virtual TblPersonal? Personal { get; set; }
        public virtual TblStudent? Student { get; set; }
    }
}
