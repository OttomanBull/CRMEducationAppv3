using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Company:BaseEntity
    {
        public string? CompanyName { get; set; }
        public string? CompanyLocation { get; set; }
        public int? CompanyPhone { get; set; }
        public string? WebSite { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDateTime { get; set; }
        public DateTime? UpdateDateTime { get; set; }
    }
}
