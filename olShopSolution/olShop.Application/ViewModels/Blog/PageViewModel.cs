using olShop.Data.Enums;

namespace olShop.Application.ViewModels.Blog
{
    public class PageViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public string Content { get; set; }

        public Status Status { get; set; }
    }
}
