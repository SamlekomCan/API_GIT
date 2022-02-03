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
//    public class EducationRepository : IEducationRepository
//    {
//        private readonly MyContext context;
//        public EducationRepository(MyContext context)
//        {
//            this.context = context;
//        }

//        public int Delete(int id)
//        {
//            var entity = context.Educations.Find(id);
//            if (entity != null)
//            {
//                context.Remove(entity);
//            }
//            var resut = context.SaveChanges();
//            return resut;
//        }

//        public IEnumerable<Education> Get()
//        {
//            return context.Educations.ToList();
//        }

//        public Education Get(int id)
//        {
//            return context.Educations.Find(id);
//        }

//        public int Post(Education edu)
//        {
//            var acce = context.Employees.Find(edu.id);
//            if (acce == null)
//            {
//                context.Educations.Add(edu);
//            }
//            var result = context.SaveChanges();
//            return result;
//        }

//        public int Put(Education edu)
//        {
//            context.Entry(edu).State = EntityState.Modified;
//            var result = context.SaveChanges();
//            return result;
//        }
//    }
//}
