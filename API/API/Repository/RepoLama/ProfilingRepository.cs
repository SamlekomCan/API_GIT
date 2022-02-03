//using API.Context;
//using API.Models;
//using API.Repository.Interface;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace API.Repository
//{
//    public class ProfilingRepository : IProfilingRepository
//    {
//        private readonly MyContext context;
//        public ProfilingRepository(MyContext context)
//        {
//            this.context = context;
//        }
//        public int Delete(string NIK)
//        {
//            var entity = context.Profilings.Find(NIK);
//            if (entity != null)
//            {
//                context.Remove(entity);
//            }
//            var resut = context.SaveChanges();
//            return resut;
//        }

//        public IEnumerable<Profiling> Get()
//        {
//            return context.Profilings.ToList();
//        }

//        public Profiling Get(string NIK)
//        {
//            return context.Profilings.Find(NIK);
//        }

//        public int Post(Profiling pro)
//        {
//            var acce = context.Accounts.Find(pro.NIK);
//            if (acce == null)
//            {
//                context.Profilings.Add(pro);
//            }
//            var result = context.SaveChanges();
//            return result;
//        }

//        public int Put(Profiling acc)
//        {
//            context.Entry(acc).State = EntityState.Modified;
//            var result = context.SaveChanges();
//            return result;
//        }
//    }
//}
