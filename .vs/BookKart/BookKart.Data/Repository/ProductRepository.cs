using BookKart.DataAccess.Data;
using BookKart.DataAccess.Repository.IRepository;
using BookKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookKart.DataAccess.Repository
{
    public class ProductRepository : Repository<ProductDALModel>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }


        public void Update(ProductDALModel obj)
        {
            _db.Products.Update(obj);
        }
    }
}
