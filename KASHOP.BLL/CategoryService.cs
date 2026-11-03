using KASHOP.DAL.DTO.Requests;
using KASHOP.DAL.DTO.Responses;
using KASHOP.DAL.Models;
using KASHOP.DAL.Repositories;
using Mapster;
using System;
using System.Collections.Generic;
using System.Text;

namespace KASHOP.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Category> _repo;

        public CategoryService(IGenericRepository<Category> repo ) 
        {
            _repo = repo;
        }
       

        public async Task<bool> CreateAsync(CategoryRequest request , CancellationToken cancellationToken = default)
        {
            var existing = await _repo.GetAsync(filter: c=>c.Name.ToLower() == request.Name.ToLower(),
                cancellationToken:cancellationToken
                );


            if (existing != null) return false;


            var category = request.Adapt<Category>();
            await _repo.CreateAsync(category, cancellationToken);
            return true;
        }

        public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CategoryResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var categories = await _repo.GetAsync(cancellationToken:cancellationToken);
            return categories.Adapt<List<CategoryResponse>>();
        }

        public CategoryResponse? GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(int id, CategoryRequest request, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<CategoryResponse?> ICategoryService.GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        Task<CategoryResponse?> ICategoryService.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
