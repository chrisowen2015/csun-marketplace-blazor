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
        private HashSet<Product> _cartProductList = new HashSet<Product>();
        private Stack<Product> _removedFromCartProductStack = new Stack<Product>(); 

        protected decimal? total = 0;

        public void AddToCart(Product product)
        {
            if(product.Price != null && !_cartProductList.Contains(product))
            {
                total += product.Price;
                _cartProductList.Add(product);
            }
        }

        public void RemoveFromCart(Product product)
        {
            if (product.Price != null && _cartProductList.Contains(product))
            {
                total -= product.Price;
            }
            _cartProductList.Remove(product);
            _removedFromCartProductStack.Push(product);
        }

        public int Length()
        {
            return _cartProductList.Count;
        }

        public decimal? GetTotal()
        {
            return total;
        }

        public bool Contains(Product product)
        {
            bool inCart = false;
            foreach(Product p in _cartProductList)
            {
                if(p.ProductId == product.ProductId)
                {
                    inCart = true;
                }
            }
            return inCart;
        }

        public HashSet<Product> GetCart()
        {
            return this._cartProductList;
        }

        public void UndoRemoveFromCart()
        {
            Product addMeBack = this._removedFromCartProductStack.Pop();
            if (!Contains(addMeBack)){
                this._cartProductList.Add(addMeBack);
            }
            else
            {
                // This is a very trolly spot to be in user-flow wise
            }
        }
        
    }

}
