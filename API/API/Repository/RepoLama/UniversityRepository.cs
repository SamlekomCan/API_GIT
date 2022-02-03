using API.Context;
using API.Models;
using API.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class UniversityRepository : IUniversityRepository
    {
        private readonly MyContext context;
        public UniversityRepository(MyContext context)
        {
            this.context = context;
        }

        public int Delete(int id)
        {
            var entity = context.Universities.Find(id);
            if (entity != null)
            {
                context.Remove(entity);
            }
            var resut = context.SaveChanges();
            return resut;
        }

        public University Get(int id)
        {
            return context.Universities.Find(id);
        }

        public IEnumerable<University> Get()
        {
            return context.Universities.ToList();
        }

        public int Post(University uni)
        {
            var acce = context.Universities.Find(uni.id);
            if (acce == null)
            {
                context.Universities.Add(uni);
            }
            var result = context.SaveChanges();
            return result;
        }

        public int Put(University uni)
        {
            context.Entry(uni).State = EntityState.Modified;
            var result = context.SaveChanges();
            return result;
        }
    }
}
