using Microsoft.EntityFrameworkCore;
using shop_api.Models;

namespace shop_api.Repository.Specifications;

public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
{
    public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> query, ISpecification<TEntity> specification)
    {
        var value = query;

        if (specification.Criteria != null)
        {
            value = query.Where(specification.Criteria);
        }

        if (specification.OrderBy != null)
        {
            value = value.OrderBy(specification.OrderBy);
        }

        if (specification.OrderByDescending != null)
        {
            value = value.OrderByDescending(specification.OrderByDescending);
        }

        if (specification.IsPagingEnabled)
        {
            value = value.Skip(specification.Skip).Take(specification.Take);
        }

        value = specification.Includes.Aggregate(value, (current, include) => current.Include(include));

        return value;
    }
}
