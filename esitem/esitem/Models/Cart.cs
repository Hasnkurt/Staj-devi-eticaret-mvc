using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using esitem.Entity;

namespace esitem.Models
{
    public class Cart
    {
        private List<CartLine> _cartLines = new List<CartLine>();
        public List<CartLine> CartLines
        {
            get { return _cartLines; }
        }
        public void AddProduct(Ürün ürün,int quantity)
        {
            var line = _cartLines.FirstOrDefault(i => i.Ürün.Id == ürün.Id);
            if(line==null)
            {
                _cartLines.Add(new CartLine() { Ürün = ürün, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }   
        }

      

        public void SilÜrün(Ürün ürün)
        {
            _cartLines.RemoveAll(i => i.Ürün.Id == ürün.Id);

        }

        public double Total()
        {
            return _cartLines.Sum(i => i.Ürün.Price * i.Quantity);
        }
        public void Clear()
        {
            _cartLines.Clear();
        }
    } 

    public class CartLine
    {
        public Ürün Ürün { get; set; }
        public int  Quantity { get; set; }

    }
}