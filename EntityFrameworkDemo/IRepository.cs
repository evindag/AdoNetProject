using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace EntityFrameworkDemo
{
    public interface IRepository<Product> where Product : class, IProduct, new()
    {
        List<Product> GetAll();
        void Add(Product product);
        void Update(Product product);
        void Delete(Product entproductity); 
    } 

    public interface IProduct
    {
        int Id { get; set; }
    }
}