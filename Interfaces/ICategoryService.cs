using PersonalFinance.API.Common;
using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ICategoryService
    {
        public Result Add(Category category);
        public Result Remove(Guid categoryId);
        public Result Update(Guid categoryId, Category updatedCategory);
        public Result<Category?> GetById(Guid categoryId);
        public Result<List<Category>> GetAll();
    }
}
