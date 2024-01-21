using System.Linq.Expressions;

namespace shop_api.Repository.Specifications;

// implementation of ISpecification interface providing includes for querying 
public class Specification<T> : ISpecification<T>
{
    public Specification()
    {
        
    }
    public Specification(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; } // defines the conditions an entity must satisfy

    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>(); // list of include expressions to be included in the query results

    public Expression<Func<T, object>> OrderBy { get; private set; }

    public Expression<Func<T, object>> OrderByDescending { get; private set; }

    public int Take { get; private set; }

    public int Skip { get; private set; }

    public bool IsPagingEnabled { get; private set; }

    protected void AddIncludes(Expression<Func<T, object>> expression)
    {
        Includes.Add(expression); // adds on the list of include expressions to be included in the query results
    }

    protected void AddOrderBy(Expression<Func<T, object>> orderByExpression)
    {
        OrderBy = orderByExpression;
    }

    protected void AddOrderByDescending(Expression<Func<T, object>> orderByDescExpression)
    {
        OrderByDescending = orderByDescExpression;
    }
    
    protected void ApplyPaging(int skip, int take)
    {
        Skip = skip;
        Take = take;
        IsPagingEnabled = true;
    }

}
