using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace netCore8_SportsShop.Models
{
    public class Cart
    {
        private List<CartLine> lineColleciton = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineColleciton
                .Where(p => p.Product.ProductID == product.ProductID)
                .FirstOrDefault();

            if (line == null)
            {
                lineColleciton.Add(new CartLine
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Product product) =>
            lineColleciton.RemoveAll(l => l.Product.ProductID == product.ProductID);

        public virtual decimal ComputeTotalValue() =>
            lineColleciton.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lineColleciton.Clear();

        public virtual IEnumerable<CartLine> Lines => lineColleciton; 
    }

    public class CartLine
    {
        public int CartLineID { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
