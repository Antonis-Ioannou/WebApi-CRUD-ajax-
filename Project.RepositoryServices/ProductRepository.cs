using Project.Database;
using Project.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.RepositoryServices
{
    public class ProductRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IEnumerable<Product> GetAll()
        {
            return db.Product.OrderBy(x=>x.Name).ToList();
        }

        public IEnumerable<Product> FilterByName(string name)
        {
            return db.Product.Where(x => x.Name.Contains(name)).ToList();
        }

        public Product GetById(int id)
        {
            return db.Product.Find(id);
        }

        public void Insert(Product product)
        {
            db.Entry(product).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(Product product)
        {
            db.Entry(product).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var product = db.Product.Find(id);
            db.Entry(product).State = EntityState.Deleted;
            db.SaveChanges();
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
