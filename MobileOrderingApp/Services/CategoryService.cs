using MobileOrderingApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileOrderingApp.Services
{
    public class CategoryService
    {
        public List<Category> GetCategories()
        {

            return new List<Category>()
            {
                new Category(){ categoryName = "Grocery", imageUrl = "grocery.png"},
                new Category(){categoryName = "Bottled Drink", imageUrl ="bottle.png"},
                new Category(){categoryName = "Cans", imageUrl ="can.png"},
                new Category(){categoryName = "Sweets", imageUrl ="candy.png"},
                new Category(){categoryName = "Chocolates", imageUrl ="chocolate.jpg"},
            };
        }

    }
}
