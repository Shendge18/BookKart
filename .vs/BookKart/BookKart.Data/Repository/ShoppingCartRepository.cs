using BookKart.DataAccess.Data;
using BookKart.DataAccess.Repository.IRepository;
using BookKart.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookKart.DataAccess.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCartDALModel>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;

        public ShoppingCartRepository(ApplicationDbContext db):base(db) 
        {
           _db = db; 
        }
       

        public void Update(ShoppingCartDALModel obj)
        {
            _db.ShoppingCarts.Update(obj);
        }
    }
}
