//using API.Context;
//using API.Models;
//using API.Repository.Interface;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace API.Repository
//{
//    public class AccountRepository : IAccountRepository
//    {
//        private readonly MyContext context;
//        public AccountRepository(MyContext context)
//        {
//            this.context = context;
//        }

//        public int Delete(string NIK)
//        {
//            var entity = context.Accounts.Find(NIK);
//            if (entity != null)
//            {
//                context.Remove(entity);
//            }
//            var resut = context.SaveChanges();
//            return resut;
//        }

//        public Account Get(string NIK)
//        {
//            return context.Accounts.Find(NIK);
//        }

//        public IEnumerable<Account> Get()
//        {
//            return context.Accounts.ToList();
//        }

//        public int Post(Account acc)
//        {
//            var acce = context.Employees.Find(acc.NIK);
//            if (acce != null)
//            {
//                context.Accounts.Add(acc);
//            }
//            var result = context.SaveChanges();
//            return result;
//        }

//        public int Put(Account acc)
//        {
//            if (context.Accounts.Find(acc.NIK) != null)
//            {
//                context.Entry(acc).State = EntityState.Modified;
//            }
//            var result = context.SaveChanges();
//            return result;
//        }
//    }
//}
