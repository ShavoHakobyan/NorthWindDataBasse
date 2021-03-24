using Northwind.Core.Abstractions.Operations;
using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Northwind.Core.Abstractions;

namespace Northwind.BLL.Operations
{
    public class ProductOperation : IProdictOperation
    {
        private readonly IRepositoryManager _productRespository;

        public ProductOperation(IRepositoryManager productRespository)
        {
            _productRespository = productRespository;
        }

        public IEnumerable<InventoryListModel> GetCatecoresProduct()
        {
            return _productRespository.Product.GetCatecoresProduct();
        }
        public IEnumerable<ProductViewModel> GetProduct()
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
    }
}
