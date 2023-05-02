﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorEcommerce.Shared
{
    public class ProductVariant
    {

        public Guid ProductId { get; set; }
        public Guid ProductTypeId { get; set; }
        public string? TypeName { get; set; } = null;
        public decimal Price { get; set; }
        public decimal OriginalPrice  { get; set; }
    }
}
