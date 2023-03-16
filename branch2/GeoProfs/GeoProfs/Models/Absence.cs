using System.ComponentModel.DataAnnotations;

namespace GeoProfs.Models
{
    public class Absence
    {
        [Key]
        public int AbsenceID { get; set; }
        public int AbsenceProposalID { get; set; }
        public AbsenceProposal AbsenceProposal { get; set; }
    }
}
