using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Northwind.Core.Abstractions;
using Northwind.Core.Abstractions.Operations;
using Northwind.Core.BusinessModels;
using Northwind.Core.Entities;
using Northwind.Core.Enum;
using Northwind.Core.Execption;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;



namespace Northwind.BLL.Operations
{
    public class UserOperations : IUserOperations
    {
        private readonly IRepositoryManager _repositories;
        public UserOperations(IRepositoryManager repositories)
        {
            _repositories = repositories;
        }

        public async Task Login(LoginModel model, HttpContext context)
        {
            Usser user = _repositories.Users.GetSingle(u => u.Email == model.Email && u.Password == model.Password)
                ?? throw new LogicExecption("Wrong username or password");

            await Authenticate(user, context);
        }

        public async Task Logout(HttpContext context)
        {
            await context.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        }

        public async Task Register(RegisterModel model, HttpContext context)
        {
            Usser user = _repositories.Users.GetSingle(u => u.Email == model.Email);
            if (user == null)
            {
                user = new Usser
                {
                    Email = model.Email,
                    Password = model.Password,
                    Role = Role.User
                };
                _repositories.Users.Add(user);
                await _repositories.SaveChangesAsync();

                await Authenticate(user, context);
            }
            else
            {
                throw new LogicExecption("User already exists");
            }

        }


        private async Task Authenticate(Usser user, HttpContext context)
        {

            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType,user.Role.ToString())
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);

            await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
