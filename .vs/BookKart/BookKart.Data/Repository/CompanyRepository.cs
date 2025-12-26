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
    public class CompanyRepository : Repository<CompanyDALModel>,ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db):base(db) 
        {
           _db = db; 
        }
       

        public void Update(CompanyDALModel obj)
        {
            _db.Companies.Update(obj);
        }
    }
}
