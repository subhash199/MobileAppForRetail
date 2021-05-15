using MobileOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOrderingApp.Services
{
   public class ProductService
    {
        public List<Item> GetItems()
        {

            return new List<Item>()
            {
                new Item(){ ID = "1", Name ="Dairy Milk", Price = 1.00, Image="dairymilk.jpg", Category="Chocolates"}
            };
            //List<Item> products = new List<Item>();

            //ServerRequest server = new ServerRequest();
            //return products = server.ItemsRequest();
        }

        
    }
}
