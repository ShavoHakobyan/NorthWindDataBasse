using Northwind.Core.Abstractions.Repositories;
using Northwind.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Northwind.DAL.Repositories
{
   public class UserRepository : RepositoryBase<Usser>,IUserRepository
    {
        public UserRepository(NorthwindContext context)
            :base(context)
        {
                
        }
    }
}
