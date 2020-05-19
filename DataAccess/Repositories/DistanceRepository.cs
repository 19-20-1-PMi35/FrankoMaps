using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class DistanceRepository
    {
        private readonly FrankoMapsDbContext dbContext;
        public DistanceRepository()
        {
            dbContext = new FrankoMapsDbContext();
        }
        public List<Distance> GetItems()
        {
            return dbContext.Set<Distance>().ToList();
        }
        public Distance GetItem(int id)
        {
            return dbContext.Set<Distance>().Find(id);
        }
        public void Create(Distance item)
        {
            dbContext.Set<Distance>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Distance item = dbContext.Set<Distance>().Find(id);
            dbContext.Set<Distance>().Remove(item);
            dbContext.SaveChanges();
        }
        public void UpdateAsync(Distance item)
        {
            var entity = GetItem(item.Id);
            entity.Id = item.Id;
            entity.FromPointId = item.FromPointId;
            entity.ToPointId = item.ToPointId;
            entity.Weight = item.Weight;
            entity.UserId = item.UserId;

            dbContext.SaveChanges();
        }
    }
}