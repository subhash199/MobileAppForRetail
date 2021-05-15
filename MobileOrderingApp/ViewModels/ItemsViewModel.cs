using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using MobileOrderingApp.Models;
using MobileOrderingApp.Views;
using System.Collections.Generic;
using MobileOrderingApp.Services;

namespace MobileOrderingApp.ViewModels
{
    public class ItemsViewModel 
    {
        private List<Item> getProductList;
        private List<Category> getCategoryList;
        public List<Item> Products
        {
            get { return getProductList = new ProductService().GetItems(); }
            set { Products = getProductList; }

        }


        public List<Category> CategoryList 
        {
            get { return getCategoryList = new CategoryService().GetCategories(); }
            set { CategoryList = getCategoryList; }
          
        }
        //public void ProductViewModel()
        //{

        //    Products = 
        //    CategoryList = new CategoryService().GetCategories();
        //}
    }
}