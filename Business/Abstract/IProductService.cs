﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetByCategory(int categoryId);
        Product GetById(int productId);

        void Add(Product product);
        void Delete(Product product);
        void Update(Product product);
    }
}
