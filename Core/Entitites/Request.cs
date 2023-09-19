using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Request:BaseEntity
    {
        public int ActivityId { get; set; }
        public int EducationId { get; set; }
        public byte DemandStatus { get; set; }
        public byte ClassNumber { get; set; }
        public byte RowNumber { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
