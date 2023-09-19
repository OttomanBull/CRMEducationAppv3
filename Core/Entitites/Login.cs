using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entitites
{
    public class Login : BaseEntity
    {
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
