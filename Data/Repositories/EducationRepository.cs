using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class EducationRepository : BaseMainRepository<Education>
    {
        public EducationRepository(MainDbContext context)
            : base(context)
        {

        }

    }
}
