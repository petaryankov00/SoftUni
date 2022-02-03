using System.Collections;
using System.Collections.Generic;

namespace SMS.ViewModels
{
    public class UserProductsViewModel
    {
        public string Username { get; set; }

        public ICollection<AllProductsViewModel> Products { get; set; }
    }
}
