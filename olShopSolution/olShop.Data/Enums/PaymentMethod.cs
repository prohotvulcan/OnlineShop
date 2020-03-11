using System.ComponentModel;

namespace olShop.Data.Enums
{
    public enum PaymentMethod
    {
        [Description("Cash on delivery")]
        CashOnDelivery,

        [Description("Online banking")]
        OnlineBanking,
        
        [Description("Payment gateway")]
        PaymentGateway,

        [Description("Visa")]
        Visa,

        [Description("Master card")]
        MasterCard,

        [Description("Paypal")]
        Paypal,

        [Description("Atm")]
        Atm
    }
}
