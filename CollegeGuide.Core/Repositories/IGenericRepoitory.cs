using CollegeGuide.Core.Entities;
using CollegeGuide.Core.Specifications;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Core.Repositories
{
    public interface IGenericRepoitory<T> where T : University
    {
        #region without Specifications
        //Get All Universities
        Task<IEnumerable<T>> GetAllAsync();

        // Get by Id
        Task<T> GetByIdAsync(int id);
        #endregion
         
        #region WithSpecifications
        Task<IEnumerable<T>> GetAllWithSpecAsync(ISpecifications<T> Spec);
        Task<T> GetByIdWithSpecAsync(ISpecifications<T> spec);
        #endregion
    }
}
