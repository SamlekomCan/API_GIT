using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IUniversityRepository
    {
        IEnumerable<University> Get();

        University Get(int id);
        int Post(University uni);
        int Put(University uni);
        int Delete(int id);
    }
}
