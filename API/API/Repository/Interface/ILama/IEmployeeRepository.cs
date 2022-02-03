using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository.Interface
{
    interface IEmployeeRepository
    {
        IEnumerable<Employee> Get();

        Employee Get(string NIK);
        int Post(Employee emp);
        int Put(Employee emp);
        int Delete(string NIK);

    }
}
