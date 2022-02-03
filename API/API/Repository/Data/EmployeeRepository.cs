using API.Context;
using API.Models;
using API.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using static API.Models.Role;

namespace API.Repository.Data
{

    public class EmployeeRepository : GeneralRepository<MyContext, Employee, string>
    {
        private readonly MyContext context;
        //private RegisterVM reg;
        public EmployeeRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        private string formatId()
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
            return format;
        }
        public int RegisterVM(RegisterVM reg)
        {
            var result = 0;
            var phone = (from s in context.Employees
                         where s.Phone == reg.Phone
                         select s)
                       .FirstOrDefault<Employee>();
            var email = (from s in context.Employees
                         where s.Email == reg.Email
                         select s)
                         .FirstOrDefault<Employee>();
            if (phone != null && email != null)
            {
                return result = 2;
            }
            else if (phone != null)
            {
                return result = 3;
            }
            else if (email != null)
            {
                return result = 4;
            }
            else if (phone == null && email == null)
            {
                var EMP = new Employee()
                {
                    NIK = formatId(),
                    FirstNama = reg.FirstNama,
                    LastName = reg.LastName,
                    Phone = reg.Phone,
                    BirthDate = reg.BirthDate,
                    Email = reg.Email,
                    GenderId = (Employee.Gender)reg.GenderId,
                    Salary = reg.Salary
                };
                context.Employees.Add(EMP);
                var ACC = new Account()
                {
                    NIK = EMP.NIK,
                    Password = BCrypt.Net.BCrypt.HashPassword(reg.Password)
                };
                context.Accounts.Add(ACC);

                var AR = new AccountRole()
                {
                    NIK = EMP.NIK,
                    Role_Id = 1
                };
                context.AccountRoles.Add(AR);

                var EDU = new Education()
                {
                    Degree = reg.Degree,
                    GPA = reg.GPA,
                    University_Id = reg.University_Id
                };
                context.Educations.Add(EDU); 
                context.SaveChanges(); //Menyimpan ID EDUCATION

                var PROF = new Profiling()
                {
                    NIK = EMP.NIK,
                    Education_Id = EDU.id
                };
                context.Profilings.Add(PROF);

                
                result = context.SaveChanges();
            }
            return result;
        }

        public IEnumerable GetRegisteredData()
        { 
            var employees = context.Employees;
            var accounts = context.Accounts;
            var profilings = context.Profilings;
            var educations = context.Educations;
            var universities = context.Universities;
            var accountRoles = context.AccountRoles;
            var roles = context.Role;

            var result = (from emp in employees
                          join acc in accounts on emp.NIK equals acc.NIK
                          join ar in accountRoles on acc.NIK equals ar.NIK 
                          join rol in roles on ar.Role_Id equals rol.id
                          join pro in profilings on acc.NIK equals pro.NIK
                          join edu in educations on pro.Education_Id equals edu.id
                          join univ in universities on edu.University_Id equals univ.id
                          select new
                          {
                              FullName = string.Concat( emp.FirstNama + " " + emp.LastName),
                              Phone = emp.Phone,
                              BirthDate = emp.BirthDate,
                              Salary = emp.Salary,
                              Email = emp.Email,
                              Degree = edu.Degree,
                              GPA = edu.GPA,
                              UnivName = univ.Name,
                              Role = rol.RoleName
                          }).ToList();


            return result;
        }
    }
}
