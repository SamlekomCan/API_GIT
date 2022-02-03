using API.Models;
using System.Collections.Generic;

namespace API.Repository.Interface
{
    interface IEducationRepository
    {
        IEnumerable<Education> Get();

        Education Get(int id);
        int Post(Education edu);
        int Put(Education edu);
        int Delete(int id);
    }
}
