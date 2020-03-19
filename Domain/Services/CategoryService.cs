using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Supermarket.Api.Domain.Models;
using Supermarket.Api.Domain.Repositories;
using Supermarket.Api.Domain.Services.Communication;
using Supermarket.Api.Persistence.Repositories;

namespace Supermarket.Api.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository categoryRepository,IUnitOfWork unitOfWork)
        {
            this._categoryRepository = categoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public async Task<CategoryResponse> DeleteAsync(int id)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null) {
                return new CategoryResponse("Category Not Found.");
            }
            try
            {
                _categoryRepository.Remove(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex) {
                // log error
                return new CategoryResponse($"An error occurred when deleting the category: {ex.Message}");
            }
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            return await _categoryRepository.ListAsync();
        }

        public async Task<CategoryResponse> SaveAsync(Category category)
        {
            try
            {
                await _categoryRepository.AddAsync(category);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(category);
            }
            catch (Exception ex) {
                // log error
                return new CategoryResponse($"An error occurred when saving the category: { ex.Message }");
            }
        }

        public async Task<CategoryResponse> UpdateAsync(int id, Category category)
        {
            var existingCategory = await _categoryRepository.FindByIdAsync(id);
            if (existingCategory == null) {
                return new CategoryResponse("Category Not Found.");
            }
            existingCategory.Name = category.Name;
            try
            {
                _categoryRepository.Update(existingCategory);
                await _unitOfWork.CompleteAsync();
                return new CategoryResponse(existingCategory);
            }
            catch (Exception ex) {
                // log error
                return new CategoryResponse($"An error occurred when updating the category: {ex.Message}");
            }
        }
    }
}
