using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public class Employee
    {
        [Key]

        public int ID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Hire Date")]
        public DateTime EnrollmentDate { get; set; }

        [Display(Name = "Role")]
        [StringLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        public string Role { get; set; }

        [Display(Name = "Team")]
        public Team Team { get; set; }

        [ForeignKey("TeamID")]

        [Required]
        [Display(Name="Mail")]
        public string Mail { get; set; }

        [Required]
        [DefaultValue(true)]
        [Display(Name = "Is Present")]
        public bool IsPresent { get; set; }

        [Display(Name = "Max. Absence Days")]
        public int MaxAbsenceDays { get; set; }

        [Display(Name = "Day of Absence")]
        public int DaysOfAbsence { get; set; }

        [Display(Name = "Absence Days Left")]
        public int AbsenceDaysLeft
        {
            get
            {
                return MaxAbsenceDays - DaysOfAbsence;
            }
        }
    }
}