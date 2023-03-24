using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{

    public class AbsenceProposal
    {
        [Key]

        public int AbsenceProposalID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Title cannot be longer than 50 characters.")]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Reason")]
        public string ReasonAbsence { get; set; }

        [Required]
        [StringLength(250, ErrorMessage = "Comments cannot be longer than 250 characters.")]
        [Column("Comment")]
        [Display(Name = "Comment")]
        public string Reasoning { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Absence Date")]
        public DateTime StartAbsenceDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Absence Date")]
        public DateTime EndAbsenceDate { get; set; }

        [Display(Name = "Accepted")]
        public bool Accepted { get; set; }

        public ICollection<Absence> Absences { get; set; }
    }
}
