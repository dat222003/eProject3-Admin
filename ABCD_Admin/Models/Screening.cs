//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ABCD_Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    public partial class Screening
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Screening()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        [DisplayName("Screening")]
        public int screeningId { get; set; }
        [DisplayName("Movie")]
        public int movieId { get; set; }
        [DisplayName("Room")]
        public int roomId { get; set; }
        [DisplayName("Reserved Time")]
        public System.DateTime reservedTime { get; set; }
        [DisplayName("Price")]
        public int price { get; set; }
    
        public virtual Movy Movy { get; set; }
        public virtual Room Room { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
