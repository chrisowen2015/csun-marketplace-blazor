using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csun_marketplace.data;

namespace csun_marketplace.services
{
    public class CartService
    {
        public List<Product> _cartProductIDList = new List<Product>();
        protected decimal? total = 0;

        public void AddToCart(Product product)
        {
            if(product.Price != null)
            {
                total += product.Price;
            }
            _cartProductIDList.Add(product);
        }
        public int Length()
        {
            return _cartProductIDList.Count;
        }
    }

}
