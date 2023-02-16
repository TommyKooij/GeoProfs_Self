using System;
using System.ComponentModel.DataAnnotations;

namespace GeoProfs.Models.GeoProfsViewModels
{
    public class EnrollmentDatesGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }

        public int WorkerCount { get; set; }
    }
}