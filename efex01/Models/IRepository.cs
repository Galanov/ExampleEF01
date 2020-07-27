﻿using System;
using System.Collections.Generic;

namespace efex01.Models
{
    public interface IRepository
    {
        IEnumerable<Product> Products { get; }
        void AddProduct(Product product);
    }
}