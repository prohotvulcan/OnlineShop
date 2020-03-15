using olShop.Application.ViewModels.System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace olShop.Application.Interfaces
{
    public interface IFunctionService
    {
        void Add(FunctionViewModel functionVm);

        void Update(FunctionViewModel functionVm);

        void Delete(string id);

        Task<List<FunctionViewModel>> GetAll(string filter);

        IEnumerable<FunctionViewModel> GetAllWithParentId(string parentId);

        FunctionViewModel GetById(string id);

        bool CheckExistedId(string id);

        void UpdateParentId(string sourceId, string targetId, Dictionary<string, int> items);

        void ReOrder(string sourceId, string targetId);

        void Save();
    }
}
