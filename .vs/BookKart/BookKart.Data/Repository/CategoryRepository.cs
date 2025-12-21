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
    public class CategoryRepository : Repository<CategoryDALModel>,ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
           _db = db; 
        }
       

        public void Update(CategoryDALModel obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
