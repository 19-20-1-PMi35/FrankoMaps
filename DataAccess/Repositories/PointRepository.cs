using System.Collections.Generic;
using DataAccess.Entities;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PointRepository
    {
        private readonly FrankoMapsDbContext dbContext;
        public PointRepository()
        {
            dbContext = new FrankoMapsDbContext();
        }
        public List<Point> GetItems()
        {
            return dbContext.Set<Point>().ToList();
        }
        public Point GetItem(int id)
        {
            return dbContext.Set<Point>().Find(id);
        }
        public void Create(Point item)
        {
            dbContext.Set<Point>().Add(item);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Point item = dbContext.Set<Point>().Find(id);
            dbContext.Set<Point>().Remove(item);
            dbContext.SaveChanges();
        }
        public void UpdateAsync(Point item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }
    }
}