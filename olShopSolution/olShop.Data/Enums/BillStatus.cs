using System.ComponentModel;

namespace olShop.Data.Enums
{
    public enum BillStatus
    {
        [Description("New bill")]
        New,

        [Description("In progress")]
        InProgress,

        [Description("Returned")]
        Returned,

        [Description("Cancelled")]
        Cancelled,

        [Description("Completed")]
        Completed
    }
}
