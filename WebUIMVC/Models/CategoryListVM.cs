using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebUIMVC.Models
{
    public class CategoryListVM
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}
