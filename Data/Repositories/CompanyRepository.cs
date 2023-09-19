using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class CompanyRepository : BaseMainRepository<Company>
    {
        public CompanyRepository(MainDbContext context)
            : base(context)
        {

        }

    }
}
