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
            List<Item> products = new List<Item>();
            ServerRequest server = new ServerRequest();
            return products = server.ItemsRequest();
        }
    }
}
