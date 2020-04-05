using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class MapRepository
    {
        private readonly FrankoMapsDbContext dbContext;
        public MapRepository()
        {
            dbContext = new FrankoMapsDbContext();
        }
        public List<Map> GetItems()
        {
            return dbContext.Set<Map>().ToList();
        }
        public Map GetItem(int id)
        {
            return dbContext.Set<Map>().Find(id);
        }
        public void Create(Map item)
        {
            dbContext.Set<Map>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Map item = dbContext.Set<Map>().Find(id);
            dbContext.Set<Map>().Remove(item);
            dbContext.SaveChanges();
        }
        public void Update(Map item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}