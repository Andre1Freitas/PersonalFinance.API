using PersonalFinance.API.Entities;

namespace PersonalFinance.API.Interfaces
{
    public interface ICategoryRepository
    {
        void Add(Category category);
        void Remove(Guid categoryId);
        void Update(Guid categoryId, Category updatedCategory);
        Category? GetById(Guid? categoryId);
        List<Category> GetAll();
    }
}
