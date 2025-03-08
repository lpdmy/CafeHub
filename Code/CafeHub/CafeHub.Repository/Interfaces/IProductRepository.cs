using CafeHub.Commons.Models;
using System.Collections.Generic;

namespace CafeHub.Repository.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product product);
        void Update(Product product);
        void Delete(int id);
    }
}
