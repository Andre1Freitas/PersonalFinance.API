using Microsoft.EntityFrameworkCore;
using PersonalFinance.API.Data;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Interfaces;

namespace PersonalFinance.API.Repositories
{
    public class CategoryEFRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryEFRepository(AppDbContext context)
        {
            _context = context;
        }

        public void Add(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Remove(Guid categoryId) => _context.Categories.Where(p => p.CategoryId == categoryId).ExecuteDelete();

        public void Update(Guid categoryId, Category updatedCategory)
        {
            _context.Categories
                .Where(p => p.CategoryId == categoryId)
                .ExecuteUpdate(s => s
                .SetProperty(f => f.Name, updatedCategory.Name));
        }

        public Category? GetById(Guid? categoryId) => _context.Categories.Find(categoryId);

        public List<Category> GetAll() => _context.Categories.ToList();
    }
}
