using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using System.ComponentModel;

namespace GeoProfs.Models
{
    public class Enrollment
    {
        [Key]
        public int EnrollmentID { get; set; }
        public int WorkerID { get; set; }
        public int DepartmentID { get; set; }
        public int CalendarID { get; set; }
        public Worker Worker { get; set; }
        public Department Department { get; set; }
    }
}
