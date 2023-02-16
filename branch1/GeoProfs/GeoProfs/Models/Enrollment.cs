using System.ComponentModel.DataAnnotations;

namespace GeoProfs.Models
{
    public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int WorkerID { get; set; }
        public int DepartmentID { get; set; }
        public Worker Worker { get; set; }
        public Department Department { get; set; }
    }
}
