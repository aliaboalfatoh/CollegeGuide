using CollegeGuide.Core.Entities;
using CollegeGuide.Core.Specifications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeGuide.Repositary
{
    public class SpecificationEvalutor<T> where T : BaseEntity 
    { 
        public static IQueryable<T> GetQuery(IQueryable<T> inputquery , ISpecifications<T> Spec )
        {

            var Query = inputquery;
            if (Spec.Criteria != null)
            {
                Query = Query.Where( Spec.Criteria );
            }
            Query = Spec.Includes.Aggregate(Query , (CurrentQuery , IncludeExpression) => CurrentQuery.Include( IncludeExpression));

            return Query;
        }
    }
}
