using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Education:BaseEntity
    {
        public string EducationName { get; set; }
        public string EducationContents { get; set; }
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreateDateTime { get; set; }
        public DateTime UpdateDateTime { get; set; }
    }
}
