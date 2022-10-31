using Microsoft.EntityFrameworkCore;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;
using PHCleanArchSample.Infra.Data.Context;

namespace PHCleanArchSample.Infra.Data.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Product> GetByIdAsync(int id)
        {
            return await _context.Products.Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductsByCategoryId(int categoryId)
        {
            return await _context.Products.Include(c => c.Category)
                .SingleOrDefaultAsync(e => e.Id == categoryId);
        }
    }
}
