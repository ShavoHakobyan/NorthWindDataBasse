using Northwind.Core.Abstractions.Operations;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions;
using Northwind.Core.Entities;
using Microsoft.Extensions.Logging;
using Northwind.Core.Execption;
using System.Threading.Tasks;
using System.Reflection;

namespace Northwind.BLL.Operations
{
    public class ProductOperation : IProdictOperation
    {
        private readonly IRepositoryManager _productRespository;
        private readonly ILogger<ProductOperation> _logger;
        public ProductOperation(IRepositoryManager productRespository, ILogger<ProductOperation> logger)
        {
            _productRespository = productRespository;
            _logger = logger;
        }

        public void Add(ProductRegistrPostModel model)
        {
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} started");
            var supplier = _productRespository.supplier.Get((int)model.SupplierId);
            if (supplier == null)
                throw new LogicExecption("There is no supplier with that Id");
            var category = _productRespository.Categories.Get((int)model.CategoryId);
            if (category == null)
                throw new LogicExecption("There is no category with that Id");
            _productRespository.Product.Add(new Product
            {
                CategoryId = model.CategoryId,
                Discontinued = model.Discontinued,
                ProductName = model.ProductName,
                QuantityPerUnit = model.QuantityPerUnit,
                SupplierId = model.SupplierId,
                UnitPrice = model.UnitPrice,
                UnitsInStock = model.UnitsInStock
            });
            _productRespository.SaveChanges();
            _logger.LogInformation($"{MethodBase.GetCurrentMethod().Name} finished");
        }



        public Product Edit(ProductViewModel model)
        {
            _logger.LogInformation("OrderOperations --- Edit method started");
            var product = _productRespository.Product.Get(model.ProductId)
                ?? throw new LogicExecption("Wrong Product Id");


            product.ProductId = product.ProductId;
            product.ProductName = model.ProductName;
            product.QuantityPerUnit = model.QuantityPerUnit;
            product.SupplierId = model.SupplierId;
            product.CategoryId = model.CategoryId;
            _productRespository.Product.Update(product);
            _productRespository.SaveChanges();
            _logger.LogInformation("OrderOperations --- Edit method finished");
            return product;
        }

        public IEnumerable<MyViewQuery> GetCatecoresProduct()
        {
            return _productRespository.Product.GetCatecoresProduct();
        }
        public IEnumerable<Core.BusinessModels.ProductViewModel> GetProduct()
        {
            var data = _productRespository.Product.GetAll();
            var result = data.Select(x => new ProductViewModel
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SupplierId = x.SupplierId,
                CategoryId = x.CategoryId,
                QuantityPerUnit = x.QuantityPerUnit

            });
            return result;

        }

        public IEnumerable<ProductsNeedReordering> GetProductsneedreorderings()
        {
            _logger.LogInformation("ProductOperation --- Number_22");
            return _productRespository.Product.GetProductsneedreorderings();
        }

        public IEnumerable<ProductsThatNeedReordering> GetProductsthatneedreorderings()
        {
            _logger.LogInformation("ProductOperation --- Number_23");
            return _productRespository.Product.GetProductsthatneedreorderings();
        }

        public async Task Remove(int id)
        {
            var product = _productRespository.Product.Get(id)
                ?? throw new LogicExecption("Wrong Product Id"); ;
           _productRespository.Product.Remove(product);
            await _productRespository.SaveChangesAsync();
        }
    }
}
