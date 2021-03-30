﻿using System;
using System.Collections.Generic;
using System.Text;

namespace XShopData.Models
{
    public class ProductDetail
    {
        public int Id { get; set; }
        public string Name{ get; set; }
        public string Sku { get; set; }

        public string Description { get; set; }
        public decimal Price { get; set; }

        public int CategoryId { get; set; }

    }
}
