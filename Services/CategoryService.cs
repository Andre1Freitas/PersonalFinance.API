using PersonalFinance.API.Interfaces;
using PersonalFinance.API.Entities;
using PersonalFinance.API.Validations;
using PersonalFinance.API.Common;
using PersonalFinance.API.Repositories;

namespace PersonalFinance.API.Services
{
    public class CategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryValidation _categoryValidation;

        public CategoryService(ICategoryRepository categoryRepository, CategoryValidation categoryValidation)
        {
            _categoryRepository = categoryRepository;
            _categoryValidation = categoryValidation;
        }

        public Result Add(Category category)
        {
            Result result = _categoryValidation.ValidateName(category.Name);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _categoryValidation.ValidateUserId(category.UserId);
            if (!result.IsSuccess)
            {
                return result;
            }
            _categoryRepository.Add(category);
            return Result.Success();
        }
        public Result Remove(Guid categoryId)
        {
            Result result = _categoryValidation.ValidateCategoryId(categoryId);
            if(!result.IsSuccess)
            {
                return result;
            }
            _categoryRepository.Remove(categoryId);
            return Result.Success();
        }

        public Result Update(Guid categoryId, Category updatedCategory)
        {
            Result result = _categoryValidation.ValidateName(updatedCategory.Name);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _categoryValidation.ValidateUserId(updatedCategory.UserId);
            if (!result.IsSuccess)
            {
                return result;
            }
            result = _categoryValidation.ValidateCategoryId(categoryId);
            if (!result.IsSuccess)
            {
                return result;
            }
            _categoryRepository.Update(categoryId, updatedCategory);
            return Result.Success();
        }
        public Result<Category?> GetById(Guid categoryId)
        {
            Result result = _categoryValidation.ValidateCategoryId(categoryId);
            if (!result.IsSuccess)
            {
                return Result<Category?>.Failure(result.Error);
            }
            return Result<Category?>.Success(_categoryRepository.GetById(categoryId));
        }

        public Result<List<Category>> GetAll()
        {
            return Result<List<Category>>.Success(_categoryRepository.GetAll());
        }
    }
}
