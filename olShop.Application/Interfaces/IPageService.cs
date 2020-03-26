using olShop.Application.ViewModels.Blog;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface IPageService
    {
        void Add(PageViewModel pageVm);

        void Update(PageViewModel pageVm);

        void Delete(int id);

        List<PageViewModel> GetAll();

        PagedResult<PageViewModel> GetAllPaging(string keyword, int page, int pageSize);

        PageViewModel GetByAlias(string alias);

        PageViewModel GetById(int id);

        void Save();
    }
}
