using olShop.Application.ViewModels.Common;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface IContactService
    {
        void Add(ContactViewModel contactVm);

        void Update(ContactViewModel contactVm);

        void Delete(int id);

        List<ContactViewModel> GetAll();

        PagedResult<ContactViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ContactViewModel GetById(string id);

        void Save();
    }
}
