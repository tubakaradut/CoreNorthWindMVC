using Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DomainModals
{
   public class Cart: IDomainModal
    {
        public Cart()
        {
            CartLines = new List<CartLine>();
        }
        public List<CartLine> CartLines { get; set; }
    }
}
