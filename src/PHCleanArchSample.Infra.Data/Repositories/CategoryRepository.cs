using Microsoft.EntityFrameworkCore;
using PHCleanArchSample.Domain.Entities;
using PHCleanArchSample.Domain.Interfaces;
using PHCleanArchSample.Infra.Data.Context;

namespace PHCleanArchSample.Infra.Data.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override async Task<Category> GetByIdAsync(int id)
        {
            return await _context.Categories.Where(x => x.Id == id).FirstOrDefaultAsync();
        }
    }
}
