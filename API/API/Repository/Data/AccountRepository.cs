using API.Context;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using bc = BCrypt.Net;

namespace API.Repository.Data
{
    public class AccountRepository : GeneralRepository<MyContext, Account, string>
    {
        private readonly MyContext context;
        public AccountRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        public int Login(AccountVM acc)
        {
            var result = 0;
            var cekEmailPhone = context.Employees.Where(e => e.Email == acc.Email
            || e.Phone == acc.Phone).FirstOrDefault();
            var pass = context.Accounts.Where(a => a.NIK == cekEmailPhone.NIK).FirstOrDefault();
            var cE = cekEmailPhone.Email.Contains(acc.Email);
            var cP = bc.BCrypt.Verify(acc.Password, pass.Password);

            if (cE == true && cP)
            {
                result = 1;
            }
            else
            {
                result = 0;
            }
            return result;
        }

        public IEnumerable profile(AccountVM acc)
        {
            var employees = context.Employees;
            var accounts = context.Accounts;
            var profilings = context.Profilings;
            var educations = context.Educations;
            var universities = context.Universities;

            var result = (from emp in employees
                          join ac in accounts on emp.NIK equals ac.NIK
                          join pro in profilings on ac.NIK equals pro.NIK
                          join edu in educations on pro.Education_Id equals edu.id
                          join univ in universities on edu.University_Id equals univ.id
                          where acc.Email == emp.Email

                          select new
                          {
                              FullName = string.Concat(emp.FirstNama + " " + emp.LastName),
                              Phone = emp.Phone,
                              BirthDate = emp.BirthDate,
                              Salary = emp.Salary,
                              Email = emp.Email,
                              Degree = edu.Degree,
                              GPA = edu.GPA,
                              UnivName = univ.Name
                          }).ToList();
            return result;
        }
        public int ForgotPassword(AccountVM acc)
        {
            Random rand = new Random();
            var cek1 = context.Employees.Where(e => e.Email == acc.Email).FirstOrDefault();
            var cek2 = context.Accounts.Where(a => a.NIK == cek1.NIK).FirstOrDefault();

            var date = DateTime.Now.AddMinutes(5);
            string r = rand.Next(0, 1000000).ToString("D6");

            var email = (from s in context.Employees
                         where s.Email == acc.Email
                         select s)
                         .FirstOrDefault<Employee>();
            if (email != null)
            {
                cek2.isUsed = false;
                cek2.OTP = int.Parse(r);
                context.Entry(cek2).State = EntityState.Modified;

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("icanikhsan88@gmail.com");
                    mail.To.Add("icanikhsan44@gmail.com");
                    mail.Subject = DateTime.Now.ToString();
                    mail.Body = r;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("icanikhsan44@gmail.com", "MrOtong04");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
            }

            return context.SaveChanges();
        }
        public int ChangePassword(AccountVM acc)
        {
            var result = 0;
            var dateExpired = DateTime.Now.AddMinutes(5);
            var cek = context.Employees.Where(e => e.Email == acc.Email).FirstOrDefault();
            var pass = context.Accounts.Where(a => a.NIK == cek.NIK).FirstOrDefault();
            if (cek != null)
            {
                if (DateTime.Now < dateExpired)
                {
                    if (acc.OTP == pass.OTP)
                    {
                        if (acc.Password == acc.ConfirmPass)
                        {
                            if (pass.isUsed == false)
                            {
                                pass.Password = bc.BCrypt.HashPassword(acc.Password);
                                context.Entry(pass).State = EntityState.Modified;
                                pass.isUsed = true;
                                result = context.SaveChanges();
                            }
                            else
                            {
                                result = 5;
                            }
                        }
                        else
                        {
                            result = 4;
                        }
                    }
                    else
                    {
                        result = 3;
                    }
                }
                else
                {
                    result = 2;
                }
            }
            return result;
        }
    }
}
