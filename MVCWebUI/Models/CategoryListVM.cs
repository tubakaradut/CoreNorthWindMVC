

using Entities.Concrete;
using System.Collections.Generic;

namespace MvcWebUI.Models
{
    public class CategoryListVM
    {
        public List<Category> Categories { get; set; }
        public int CurrentCategory { get; set; }
    }
}
