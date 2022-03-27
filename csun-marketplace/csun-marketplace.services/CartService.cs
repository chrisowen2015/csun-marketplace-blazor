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
        public HashSet<Product> _cartProductList = new HashSet<Product>();
        protected decimal? total = 0;

        public void AddToCart(Product product)
        {
            if(product.Price != null)
            {
                total += product.Price;
            }
            _cartProductList.Add(product);
        }

        public void RemoveFromCart(Product product)
        {
            if (product.Price != null)
            {
                total -= product.Price;
            }
            _cartProductList.Remove(product); 
        }

        public int Length()
        {
            return _cartProductList.Count;
        }
    }

}
