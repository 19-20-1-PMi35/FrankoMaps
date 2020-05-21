using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class FavouriteRepository
    {
        private readonly FrankoMapsDbContext dbContext;
        public FavouriteRepository()
        {
            dbContext = new FrankoMapsDbContext();
        }
        public List<Favourite> GetItems()
        {
            return dbContext.Set<Favourite>().ToList();
        }
        public Favourite GetItem(int id)
        {
            return dbContext.Set<Favourite>().Find(id);
        }
        public void Create(Favourite item)
        {
            dbContext.Set<Favourite>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Favourite item = dbContext.Set<Favourite>().Find(id);
            dbContext.Set<Favourite>().Remove(item);
            dbContext.SaveChanges();
        }
        public void UpdateAsync(Favourite item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}