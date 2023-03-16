using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public enum Role
    {
        Employee, TeamManager, BoardMember
    }
    public class Worker
    {

        [Key]
        public int ID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        public string FirstMidName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Enrollment Date")]
        public DateTime EnrollmentDate { get; set; }
       
        [Display(Name = "Full Name")]
        public string FullName
        {
            get
            {
                return LastName + ", " + FirstMidName;
            }
        }
        public Role? Role { get; set; }
        [Required]
        [Column("Role")]
        [Display(Name = "Role")]

        [DefaultValue(true)]
        [Column("IsPresent")]
        [Display(Name = "Is Present")]
        public bool IsPresent { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
