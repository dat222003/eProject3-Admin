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
    
    public partial class RoomSeat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RoomSeat()
        {
            this.Tickets = new HashSet<Ticket>();
        }
    
        public int roomId { get; set; }
        public int seatId { get; set; }
        public bool isAvailable { get; set; }
    
        public virtual Room Room { get; set; }
        public virtual Seat Seat { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
