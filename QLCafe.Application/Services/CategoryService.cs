using System.Collections.Generic;
using QLCafe.Infrastructure.Repositories;

namespace QLCafe.Application.Services
{
    public class CategoryService
    {
        private readonly CategoryRepository _repo;
        public CategoryService(string connectionString)
        {
            _repo = new CategoryRepository(connectionString);
        }

        public bool Exists(string name) => _repo.Exists(name);
        public int Create(string name) => _repo.Create(name);
        public List<string> GetNames() => _repo.GetAllNames();
        public List<(int Id, string Name)> GetAllPairs() => _repo.GetAllPairs();
        public bool DeleteWithProducts(int categoryId) => _repo.DeleteCategoryAndProducts(categoryId);
    }
}