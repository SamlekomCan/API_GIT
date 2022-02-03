using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IProfilingRepository
    {
        IEnumerable<Profiling> Get();

        Profiling Get(string NIK);
        int Post(Profiling acc);
        int Put(Profiling acc);
        int Delete(string NIK);
    }
}
