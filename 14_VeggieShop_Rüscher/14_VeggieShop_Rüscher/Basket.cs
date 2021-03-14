using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

namespace _14_VeggieShop_Rüscher
{
    public class Basket
    {
        //fields
        List<Veggi> basket = new List<Veggi>();
        Veggi veggi;
        FileIO file = new FileIO();

        //properties
        public double TotalPrice
        {
            get
            {
                double totalPrice = 0;

                foreach(Veggi v in basket)
                {
                    totalPrice = totalPrice + (v.Amount * v.Price);
                }

                return totalPrice;
            }
        }
        public  List<Veggi> Veggies
        {
            get
            {
                basket = file.ReadFile();
                return basket;
            }
        }

        //methods
        public void AddVeggiToBasket(Veggi v)
        {
            if (basket.Contains(v))
            {
                v.BuyMore(v.Amount);
            }
            else
            {
                basket.Add(v);
                file.SaveVeggiToFile(v);
            }
            file.UpdatedVeggies(basket);
        }

        public void RemoveVeggi(Veggi v, double amount)
        {
            v.PutBack(amount);
            if(v.Amount <= 0)
            {
                basket.Remove(v);
            }
            file.UpdatedVeggies(basket);
        }
    }
}
