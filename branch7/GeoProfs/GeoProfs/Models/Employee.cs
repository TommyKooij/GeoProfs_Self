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

        /*        [Display(Name = "Full Name")]
                public string FullName
                {
                    get
                    {
                        return LastName + ", " + FirstMidName;
                    }
                }*/

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }

        //public int RoleID { get; set; }

        //[ForeignKey("RoleID")]
        [Display(Name = "Role")]
        public string Role { get; set; }

        [Required]
        [Display(Name = "Team")]
        [StringLength(50, ErrorMessage = "Team cannot be longer than 50 characters.")]
        public string Team { get; set; }

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