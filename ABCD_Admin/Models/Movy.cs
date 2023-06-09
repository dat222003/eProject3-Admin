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
    using System.ComponentModel.DataAnnotations;

    public partial class Movy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movy()
        {
            this.Screenings = new HashSet<Screening>();
            this.Tickets = new HashSet<Ticket>();
        }

        [DisplayName("Movie")]
        public int movieId { get; set; }
        [DisplayName("Movie Title")]
        [Required]
        public string movieTitle { get; set; }
        [DisplayName("Description")]
        [Required]
        public string movieDescription { get; set; }
        [DisplayName("Release Date")]
        [Required]
        public System.DateTime releaseDate { get; set; }
        [DisplayName("Duration")]
        [Required]
        public int duration { get; set; }
        [DisplayName("Status")]
        [Required]
        [Range(0, 1)]
        public byte status { get; set; }
        [DisplayName("Image Path")]
        public string imagePath { get; set; }
        [Required]
        [DisplayName("Trailer Link")]
        public string trailerLink { get; set; }
        [Required]
        [Range(0, 5)]
        [DisplayName("Rating")]
        public Nullable<int> rating { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Screening> Screenings { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
