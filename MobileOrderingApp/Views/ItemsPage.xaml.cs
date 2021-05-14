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

        public ItemsPage()
        {
            InitializeComponent();
            BindingContext = _viewModel;
            
        }

     
    }
}