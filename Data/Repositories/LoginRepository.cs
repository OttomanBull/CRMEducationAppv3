using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class LoginRepository : BaseMainRepository<Login>
    {
        public LoginRepository(MainDbContext context)
            : base(context)
        {

        }

    }
}
