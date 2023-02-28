using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public enum Reason
    {
        Sick, Vacation, DayOff
    }
    public class AbsenceProposal
    {
        public int AbsenceProposalID { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "ID")]
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
        public Reason? Reason { get; set; }
        [Required]
        [Column("Reason")]
        [Display(Name = "Reason")]
        public string Reasoning { get; set; }
        [Required]
        [StringLength(250)]
        [Column("Reasoning")]
        [Display(Name = "Reasoning")]
        public DateTime AbsenceDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Absence Date")]

        public ICollection<Absence> Absences { get; set; }
    }
}
