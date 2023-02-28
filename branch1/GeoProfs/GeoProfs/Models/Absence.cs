using System.ComponentModel.DataAnnotations;

namespace GeoProfs.Models
{
    public class Absence
    {
        public int AbsenceID { get; set; }
        public int AbsenceProposalID { get; set; }
        public AbsenceProposal AbsenceProposal { get; set; }
    }
}
