using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MobileBackend;
using Models;

namespace Identity_Server.DI.ProductDI
{
    public class ProductDI
    {
        private ApplicationContext _applicationContext;

        public ProductDI(ApplicationContext _application)
        {
            _applicationContext = _application;
        }

        public Product FindProductByName(string searchName)
        {
            return _applicationContext.Products.FirstOrDefault(x => x.Name.Contains(searchName));
        }

        public async Task<bool> AddProduct(AddProductModel newProduct)
        {
            try
            {
                await _applicationContext.AddProductModels.AddAsync(newProduct);
                await _applicationContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
