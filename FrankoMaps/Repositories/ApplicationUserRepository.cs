using FrankoMaps.Areas.Identity.Data;
using FrankoMaps.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace FrankoMaps.Repositories
{
    public class ApplicationUserRepository
	{
        private readonly ApplicationUserDbContext dbContext;
        public ApplicationUserRepository()
        {
            dbContext = new ApplicationUserDbContext();
        }
        public List<ApplicationUser> GetItems()
        {
            return dbContext.Set<ApplicationUser>().ToList();
        }
        public ApplicationUser GetItem(int id)
        {
            return dbContext.Set<ApplicationUser>().Find(id);
        }
        public void Create(ApplicationUser item)
        {
            dbContext.Set<ApplicationUser>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(string id)
        {
            ApplicationUser item = dbContext.Set<ApplicationUser>().Find(id);
            dbContext.Set<ApplicationUser>().Remove(item);
            dbContext.SaveChanges();
        }
        public void Update(ApplicationUser item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}
