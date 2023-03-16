using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GeoProfs.Models
{
    [Table("Event")]
    public class CalendarEvent
    {
        [Key]

        [Required]
        [StringLength(50)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        [Column("Title")]
        [Display(Name = "Title")]
        public string Title { get; set; }
        
        [Required]
        [StringLength(590, ErrorMessage = "Description cannot be longer than 500 characters.")]
        [Column("Description")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime StartDate { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        [Column("Accepted")]
        [Display(Name = "Accepted")]
        public bool Accepted { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
