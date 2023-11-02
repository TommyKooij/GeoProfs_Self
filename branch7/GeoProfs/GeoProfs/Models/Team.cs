using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public class Team
    {

        [Key]
        public int TeamID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Team name cannot be longer than 50 characters.")]
        [Column("TeamName")]
        [Display(Name = "Team Name")]
        public string TeamName { get; set; }

        [Required]
        [Column("Capacity")]
        [Display(Name = "Capacity")]
        public int Capacity { get; set; }

        [Required]
        [Column("Budget")]
        [Display(Name = "Budget")]
        public int Budget { get; set; }

        [Required]
        [Column("Members")]
        [Display(Name = "Members")]
        public ICollection<Employee> Employees { get; set; }
    }
}
