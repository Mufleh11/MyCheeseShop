﻿
using System.Security.Cryptography.X509Certificates;



namespace MyCheeseShop.Model
{
    public class ShoppingCart
    {
        public event Action? OnCartUpdated;
        public List<CartItem> _items;

        public ShoppingCart()
        {
            _items = [];
        }

        public void AddItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item == null)
                _items.Add(new CartItem { Cheese = cheese, Quantity = quantity });

            else
                item.Quantity += quantity;



            OnCartUpdated?.Invoke();









        }
        public decimal Total()
        {
            return _items.Sum(item => item.Cheese.Price * item.Quantity);
        }

        public void SetItems(IEnumerable<CartItem> items)
        {
            
            _items = items.ToList();
            OnCartUpdated?.Invoke();
        }

        public void RemoveItem(Cheese cheese)
        {
            var item = _items.RemoveAll(item => item.Cheese.Id == cheese.Id);
            OnCartUpdated?.Invoke();

        }

        public void DecreaseItem(Cheese cheese, int quantity)
        {
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            if (item is not null)
            {
                item.Quantity = quantity;
                if (item.Quantity <= 0)
                    _items.Remove(item);
            }
            OnCartUpdated?.Invoke();


        }

        public int Count()
        {
            return _items.Count;
        }



        public IEnumerable<CartItem> GetItems()
        {
            return _items;
        }


        public int GetQuantity(Cheese cheese)
        {
           
            var item = _items.FirstOrDefault(item => item.Cheese.Id == cheese.Id);
            return item?.Quantity ?? 0;
     
        
        }
      

        public void Clear ()
        {
            _items.Clear();
            OnCartUpdated?.Invoke();
        }

    }

}
