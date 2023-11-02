using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoProfs.Models
{
    public class Absence
    {
        [Key]
        public int AbsenceID { get; set; }
        [ForeignKey("AbsenceProposalID")] 
        public int AbsenceProposalID { get; set; }
        public AbsenceProposal AbsenceProposal { get; set; }
    }
}