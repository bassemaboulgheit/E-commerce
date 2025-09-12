﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_commerce.Models
{
    public class Cart : BaseModels<int>
    {
        public DateTime CreatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;


        public int? UserId { get; set; }
        public User? User { get; set; }

        public List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
