using System.Linq.Expressions;

namespace shop_api.Repository.Specifications;

public interface ISpecification<T>
{
    // this criteria expression is basically one that defines the conditions an entity needs to satisfy.
    Expression<Func<T, bool>> Criteria { get; }

    // gets the list of include classes specifying those entities that needs to be included in query results.
    List<Expression<Func<T, object>>> Includes { get; }
    Expression<Func<T, object>> OrderBy { get; } 
    Expression<Func<T, object>> OrderByDescending { get; }
    int Take { get; }
    int Skip { get; }
    bool IsPagingEnabled { get; }

}
