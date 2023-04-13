using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public class Role
    {
        [Key]

        public int RoleID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Role cannot be longer than 50 characters.")]
        [Column("Role")]
        [Display(Name = "Role")]
        public string RoleName { get; set; }

        //public Worker Worker { get; set; }
    }
}
