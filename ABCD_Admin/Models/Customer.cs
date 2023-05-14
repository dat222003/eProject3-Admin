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

    public partial class Customer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Customer()
        {
            this.Feedbacks = new HashSet<Feedback>();
            this.Orders = new HashSet<Order>();
            this.Tickets = new HashSet<Ticket>();
        }

        [DisplayName("Customer")]
        public int customerId { get; set; }
        [DisplayName("UserName")]
        public string userName { get; set; }
        [DisplayName("Password")]
        public string password { get; set; }
        [DisplayName("Email")]
        public string email { get; set; }
        [DisplayName("FullName")]
        public string fullName { get; set; }
        [DisplayName("BirthDate")]
        public System.DateTime birthDate { get; set; }
        [DisplayName("CardNumber")]
        public string cardNumber { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
