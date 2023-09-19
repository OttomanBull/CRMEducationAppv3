using Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class PersonRepostiroy : BaseMainRepository<Person>
    {
        public PersonRepostiroy(MainDbContext context)
            : base(context)
        {

        }

    }
}
