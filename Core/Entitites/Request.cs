using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Request:BaseEntity
    {
        public int? PersonId { get; set; }
        public int? ActivityId { get; set; }
        public bool? DemandStatus { get; set; }
        public int? NumberOfPeople { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
