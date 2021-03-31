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
            var product = _productRespository.Product.GetSingle(u => u.ProductId == model.ProductId);
            if (product != null)
                throw new LogicExecption("There is no Product with that Id");
            //  var categpry = _productRespository.OrderDetail.GetSingle(u => u.ca== model.CategoryId);
            //if (categpry == null)
            //    throw new LogicExecption("There is no employee with that Id");
            _productRespository.Product.Add(model);
            _productRespository.SaveChanges();

            _productRespository.Product.Add(model);
            _productRespository.SaveChanges();
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

        public async Task Remove(int id)
        {
            var product = _productRespository.Product.Get(id)
                ?? throw new LogicExecption("Wrong Product Id"); ;
           _productRespository.Product.Remove(product);
            await _productRespository.SaveChangesAsync();
        }
    }
}
