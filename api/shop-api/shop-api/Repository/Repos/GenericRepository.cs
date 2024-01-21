using Microsoft.EntityFrameworkCore;
using shop_api.Data;
using shop_api.Models;
using shop_api.Repository.Interfaces;
using shop_api.Repository.Specifications;

namespace shop_api.Repository.Repos;
public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly ApplicationStoreDbContext _context;

    public GenericRepository(ApplicationStoreDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await _context.Set<T>().ToListAsync(); // get all the data from any T entity, less the Product, that stores brand and product type data as well, so we need to do specification to get these two types of data
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _context.Set<T>().FindAsync(id); // get only one register by the ID from any T entity
    }

    public async Task<T> GetsValueWithSpecification(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).FirstOrDefaultAsync();
    }

    public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> specification)
    {
        return await ApplySpecification(specification).ToListAsync();
    }

    public async Task<int> CountAsync(ISpecification<T> spec)
    {
        return await ApplySpecification(spec).CountAsync();
    }

    private IQueryable<T> ApplySpecification(ISpecification<T> specification)
    {
        return SpecificationEvaluator<T>.GetQuery(_context.Set<T>().AsQueryable(), specification);
    }
}
