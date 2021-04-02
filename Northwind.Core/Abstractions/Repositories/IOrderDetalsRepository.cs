﻿using System;
using System.Collections.Generic;
using System.Text;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;

namespace Northwind.Core.Abstractions.Repositories
{
    public interface IOrderDetalsRepository : IRepositoryBase<OrderDetail>
    {
        void Add(OrderDetailPostModel model);
    }
}
