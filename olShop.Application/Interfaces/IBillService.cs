﻿using olShop.Application.ViewModels.Product;
using olShop.Data.Enums;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface IBillService
    {
        void Create(BillViewModel billVm);

        void Update(BillViewModel billVm);

        PagedResult<BillViewModel> GetAllPaging(string startDate, string endDate, string keyword, int pageIndex, int pageSize);

        BillViewModel GetDetail(int billId);

        BillDetailViewModel CreateDetail(BillDetailViewModel billDetailVm);

        void DeleteDetail(int productId, int billId, int colorId, int sizeId);

        void UpdateStatus(int orderId, BillStatus billStatus);

        List<BillDetailViewModel> GetBillDetails(int billId);

        List<ColorViewModel> GetColors();

        List<SizeViewModel> GetSizes();

        ColorViewModel GetColor(int id);

        SizeViewModel GetSize(int id);

        void Save();
    }
}
