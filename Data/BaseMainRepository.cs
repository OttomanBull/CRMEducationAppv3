using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class BaseMainRepository<T> : BaseRepository<T, MainDbContext>
             where T : BaseEntity
    {
        public BaseMainRepository(MainDbContext context)
            : base(context)
        {

        }
    }
}
