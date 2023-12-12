﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineProductStore.Shared.DTO
{
    public class CartProductDTO
    {
        public int ProductId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl {  get; set; } = string.Empty;
        public decimal Price { get; set; }
        public int Quantity { get; set; } = 1;
    }
}
