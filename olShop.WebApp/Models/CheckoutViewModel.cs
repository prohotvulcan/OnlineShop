using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using olShop.Data.Enums;
using olShop.Utilities.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace olShop.WebApp.Models
{
    public class CheckoutViewModel : BillViewModel
    {
        public List<ShoppingCartViewModel> Carts { get; set; }

        public List<EnumModel> PaymentMethods 
        { 
            get 
            {
                return ((PaymentMethod[])Enum
                    .GetValues(typeof(PaymentMethod)))
                    .Select(x => new EnumModel { Value = (int)x, Name = x.GetDescription() })
                    .ToList();
            } 
        }
    }
}
