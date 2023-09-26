using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Activity:BaseEntity
    {
        public int? EducationId { get; set; }
        public int? InstructorId { get; set; }
        public bool? ActivityType { get; set; }
        public string? ActivityLocation { get; set; }
        public byte? ClassLowerLimit { get; set; }
        public byte? ClassUpperLimit { get; set; }
        public string? ActivityDate { get; set; }
        public string? ActivityPrice { get; set; }
        public string? Certificate { get; set; }
        public string? CreateDateTime { get; set; }
        public string? UpdateDateTime { get; set; }
    }
}
