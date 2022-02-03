using API.Context;
using API.Models;

namespace API.Repository.Data
{
    public class UniversityRepository : GeneralRepository<MyContext, University, int>
    {
        private readonly MyContext context;
        public UniversityRepository(MyContext myContext) : base(myContext)
        {
            this.context = myContext;
        }

        public int DeleteKey(University uni) {
            var result = context.Universities.Find(uni.id);
            if (result != null)
            {
                context.Universities.Remove(result);
            }

            return context.SaveChanges();
        }
    }
}
