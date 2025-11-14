using CafeWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeWinApp.Data
{
    public class ProductRepository
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            LoadData();
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json);
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product p)
        {
            if (_products.Any(x => x.Id == p.Id))
                throw new Exception("ID already exists!");

            _products.Add(p);
            SaveData();
        }

        public void Update(Product p)
        {
            var old = _products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                throw new Exception("Product not found!");

            old.Name = p.Name;
            old.Size = p.Size;
            old.Price = p.Price;
            old.Category = p.Category;
            old.Description = p.Description;

            SaveData();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Product not found!");

            _products.Remove(p);
            SaveData();
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Id.ToString().Contains(keyword))
            .ToList();
        }

        public List<Product> SortByName(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Name).ToList()
                : _products.OrderByDescending(p => p.Name).ToList();
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Price).ToList()
                : _products.OrderByDescending(p => p.Price).ToList();
        }

        public int GetNextId()
        {
            if (_products.Count == 0) return 1;
            return _products.Max(p => p.Id) + 1;
        }
    }
}
using CafeWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeWinApp.Data
{
    public class ProductRepository
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            LoadData();
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json);
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product p)
        {
            if (_products.Any(x => x.Id == p.Id))
                throw new Exception("ID already exists!");

            _products.Add(p);
            SaveData();
        }

        public void Update(Product p)
        {
            var old = _products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                throw new Exception("Product not found!");

            old.Name = p.Name;
            old.Size = p.Size;
            old.Price = p.Price;
            old.Category = p.Category;
            old.Description = p.Description;

            SaveData();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Product not found!");

            _products.Remove(p);
            SaveData();
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Id.ToString().Contains(keyword))
            .ToList();
        }

        public List<Product> SortByName(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Name).ToList()
                : _products.OrderByDescending(p => p.Name).ToList();
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Price).ToList()
                : _products.OrderByDescending(p => p.Price).ToList();
        }

        public int GetNextId()
        {
            if (_products.Count == 0) return 1;
            return _products.Max(p => p.Id) + 1;
        }
    }
}
using CafeWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeWinApp.Data
{
    public class ProductRepository
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            LoadData();
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json);
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product p)
        {
            if (_products.Any(x => x.Id == p.Id))
                throw new Exception("ID already exists!");

            _products.Add(p);
            SaveData();
        }

        public void Update(Product p)
        {
            var old = _products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                throw new Exception("Product not found!");

            old.Name = p.Name;
            old.Size = p.Size;
            old.Price = p.Price;
            old.Category = p.Category;
            old.Description = p.Description;

            SaveData();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Product not found!");

            _products.Remove(p);
            SaveData();
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Id.ToString().Contains(keyword))
            .ToList();
        }

        public List<Product> SortByName(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Name).ToList()
                : _products.OrderByDescending(p => p.Name).ToList();
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Price).ToList()
                : _products.OrderByDescending(p => p.Price).ToList();
        }

        public int GetNextId()
        {
            if (_products.Count == 0) return 1;
            return _products.Max(p => p.Id) + 1;
        }
    }
}
using CafeWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeWinApp.Data
{
    public class ProductRepository
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            LoadData();
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json);
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product p)
        {
            if (_products.Any(x => x.Id == p.Id))
                throw new Exception("ID already exists!");

            _products.Add(p);
            SaveData();
        }

        public void Update(Product p)
        {
            var old = _products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                throw new Exception("Product not found!");

            old.Name = p.Name;
            old.Size = p.Size;
            old.Price = p.Price;
            old.Category = p.Category;
            old.Description = p.Description;

            SaveData();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Product not found!");

            _products.Remove(p);
            SaveData();
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Id.ToString().Contains(keyword))
            .ToList();
        }

        public List<Product> SortByName(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Name).ToList()
                : _products.OrderByDescending(p => p.Name).ToList();
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Price).ToList()
                : _products.OrderByDescending(p => p.Price).ToList();
        }

        public int GetNextId()
        {
            if (_products.Count == 0) return 1;
            return _products.Max(p => p.Id) + 1;
        }
    }
}
using CafeWinApp.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace CafeWinApp.Data
{
    public class ProductRepository
    {
        private readonly string _filePath = "products.json";
        private List<Product> _products;

        public ProductRepository()
        {
            if (!File.Exists(_filePath))
                File.WriteAllText(_filePath, "[]");

            LoadData();
        }

        private void LoadData()
        {
            var json = File.ReadAllText(_filePath);
            _products = JsonSerializer.Deserialize<List<Product>>(json);
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(_products, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);
        }

        public List<Product> GetAll()
        {
            return _products.OrderBy(p => p.Id).ToList();
        }

        public Product GetById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product p)
        {
            if (_products.Any(x => x.Id == p.Id))
                throw new Exception("ID already exists!");

            _products.Add(p);
            SaveData();
        }

        public void Update(Product p)
        {
            var old = _products.FirstOrDefault(x => x.Id == p.Id);
            if (old == null)
                throw new Exception("Product not found!");

            old.Name = p.Name;
            old.Size = p.Size;
            old.Price = p.Price;
            old.Category = p.Category;
            old.Description = p.Description;

            SaveData();
        }

        public void Delete(int id)
        {
            var p = _products.FirstOrDefault(x => x.Id == id);
            if (p == null)
                throw new Exception("Product not found!");

            _products.Remove(p);
            SaveData();
        }

        public List<Product> Search(string keyword)
        {
            keyword = keyword.ToLower();
            return _products.Where(p =>
                p.Name.ToLower().Contains(keyword) ||
                p.Category.ToLower().Contains(keyword) ||
                p.Description.ToLower().Contains(keyword) ||
                p.Id.ToString().Contains(keyword))
            .ToList();
        }

        public List<Product> SortByName(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Name).ToList()
                : _products.OrderByDescending(p => p.Name).ToList();
        }

        public List<Product> SortByPrice(bool ascending = true)
        {
            return ascending
                ? _products.OrderBy(p => p.Price).ToList()
                : _products.OrderByDescending(p => p.Price).ToList();
        }

        public int GetNextId()
        {
            if (_products.Count == 0) return 1;
            return _products.Max(p => p.Id) + 1;
        }
    }
}
