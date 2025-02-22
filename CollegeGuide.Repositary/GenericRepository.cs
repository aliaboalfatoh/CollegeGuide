using CollegeGuide.Core.Entities;
using CollegeGuide.Core.Repositories;
using CollegeGuide.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Repositary
{
    public class GenericRepository<T> : IGenericRepoitory<T> where T : University
    {
        private readonly StoreContext _dbContext;

        public GenericRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }
        #region WithoutSpecifications
        public async Task<IEnumerable<T>> GetAllAsync()
        {

            if (typeof(T) == typeof(University))
            {
                return (IEnumerable<T>)await _dbContext.Universities.Include(P => P.Colleges).Include(P => P.FinancialAids).ToListAsync();


            }
            return await _dbContext.Set<T>().ToListAsync();
        }
     
  
      
        public async Task<T> GetByIdAsync(int id)
        {
            // return await _dbContext.Set<T>().Where(X => X.Col_Id == id).FirstOrDefaultAsync();
            return await _dbContext.Set<T>().FindAsync(id);
            //return await _dbContext.Set<T>().Where(P => P.Id == id).Include(P => P.University).Include(P => P.Recommendations);
        }
        #endregion
        public async Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecification(Spec).ToListAsync();
        }
        public async Task<T> GetByIdWithSpecAsync(ISpecifications<T> Spec)
        {
            return await ApplySpecification(Spec).FirstOrDefaultAsync();
        }
        private IQueryable<T> ApplySpecification(ISpecifications<T> Spec)
        {
            return SpecificationEvalutor<T>.GetQuery(_dbContext.Set<T>(), Spec);
        }
    }
}