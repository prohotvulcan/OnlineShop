using System.Collections.Generic;

namespace olShop.Utilities.Dtos
{
    public class PagedResult<T> : PagedResultBase where T : class
    {
        public IList<T> Results { get; set; }

        public PagedResult()
        {
            this.Results = new List<T>();
        }
    }
}
