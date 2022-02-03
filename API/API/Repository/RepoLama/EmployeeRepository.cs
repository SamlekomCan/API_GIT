using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly MyContext context;
        public EmployeeRepository(MyContext context)
        {
            this.context = context;
        }
        public int Delete(string NIK)
        {
            var entity = context.Employees.Find(NIK);
            if(entity != null)
            {
                context.Remove(entity);
            }
            var resut = context.SaveChanges();
            return resut;
        }

        public IEnumerable<Employee> Get()
        {
            return context.Employees.ToList();
        }

        public Employee Get(string NIK)
        {
            return context.Employees.Find(NIK);
        }

        public int Post(Employee emp)
        {
            var idDate = DateTime.Now.ToString("yyyy");
            var lastId = context.Employees.ToList().Count();
            var format = idDate + "-" + lastId;
            while (!format.Equals(Get(format)))
            {
                format = idDate + "-" + (lastId += 1);
                if (Get(format) == null)
                {
                    break;
                }
            }

            var phone = (from s in context.Employees 
                         where s.Phone == emp.Phone select s)
                         .FirstOrDefault<Employee>();
            var email = (from s in context.Employees
                         where s.Email == emp.Email
                         select s)
                         .FirstOrDefault<Employee>();
            if (phone != null && email != null)
            {
                return 2;
            }
            else if (phone != null)
            {
                return 3;
            }else if(email != null)
            {
                return 4;
            }
            else
            {
                emp.NIK = format;
                context.Employees.Add(emp);
            }
            var result = context.SaveChanges();
            return result;
        }

        public int Put(Employee emp)
        {
            var phone = (from s in context.Employees
                         where s.Phone == emp.Phone
                         select s)
                         .FirstOrDefault<Employee>();
            var email = (from s in context.Employees
                         where s.Email == emp.Email
                         select s)
                         .FirstOrDefault<Employee>();
            if (phone == null && email == null)
            {
                context.Entry(emp).State = EntityState.Modified;
            }
            var result = context.SaveChanges();
            return result;
        }
    }
}
