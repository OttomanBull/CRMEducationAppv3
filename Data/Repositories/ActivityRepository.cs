using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ActivityRepository : BaseMainRepository<Activity>
    {
        public ActivityRepository(MainDbContext context)
            : base(context)
        {
            //git push try
        }

    }
}
