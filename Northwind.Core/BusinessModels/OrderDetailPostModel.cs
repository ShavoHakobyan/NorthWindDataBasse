using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Northwind.Core.BusinessModels
{
    public class OrderDetailPostModel
    {
        [Required]
        public int OrderId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public decimal UnitPrice { get; set; }
        [Required]
        public short Quantity { get; set; }
        [Required]
        public float Discount { get; set; }
    }
}
