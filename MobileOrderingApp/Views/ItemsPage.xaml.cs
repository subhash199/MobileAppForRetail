using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MobileOrderingApp.Models;
using MobileOrderingApp.Views;
using MobileOrderingApp.ViewModels;

namespace MobileOrderingApp.Views
{
    public partial class ItemsPage : ContentPage
    {
        ItemsViewModel _viewModel = new ItemsViewModel();
        List<Item> productList = new List<Item>();

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            
        }

        private void Bag_Clicked(object sender, EventArgs e)
        {
            string ID = (sender as Button).ClassId;
            productList.Add(_viewModel.Products.Find(Item => Item.ID == ID));
            productList.Last().QTY = "3"; // Need to add qty_btn text
            
            ItemCount.Text = productList.Count.ToString();

        }
    }
}