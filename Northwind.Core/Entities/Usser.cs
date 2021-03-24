using Northwind.Core.Enum;
using System;
using System.Collections.Generic;

#nullable disable

namespace Northwind.Core.Entities
{
    public partial class Usser
    {
        public int Id { get; set; }
        public Role Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
