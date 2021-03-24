using Microsoft.AspNetCore.Http;
using Northwind.Core.BusinessModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Core.Abstractions.Operations
{
   public interface IUserOperations
    {
        Task Logout(HttpContext context);
        Task Register(RegisterModel model, HttpContext context);
        Task Login(LoginModel model, HttpContext context);
    }
}
