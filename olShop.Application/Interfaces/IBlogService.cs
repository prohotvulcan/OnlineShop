using olShop.Application.ViewModels.Blog;
using olShop.Application.ViewModels.Common;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface IBlogService
    {
        BlogViewModel Add(BlogViewModel blogVm);

        void Update(BlogViewModel blogVm);

        void Delete(int id);

        List<BlogViewModel> GetAll();

        PagedResult<BlogViewModel> GetAllPaging(string keyword, int pageSize, int page);

        List<BlogViewModel> GetLastest(int top);

        List<BlogViewModel> GetHotProduct(int top);

        List<BlogViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow);

        List<BlogViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow);

        List<BlogViewModel> GetList(string keyword);

        List<BlogViewModel> GetRelatedBlogs(int id, int top);

        List<string> GetListByName(string name);

        BlogViewModel GetById(int id);

        void Save();

        void IncreaseView(int id);

        List<BlogViewModel> GetListByTag(string tagId, int page, int pageSize, out int totalRow);

        List<TagViewModel> GetListTag(string searchText);

        TagViewModel GetTag(string tagId);
    }
}
