using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using olShop.Utilities.Dtos;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface IProductService
    {
        ProductViewModel Add(ProductViewModel productVm);

        void Update(ProductViewModel productVm);

        void Delete(ProductViewModel productVm);

        List<ProductViewModel> GetAll();

        PagedResult<ProductViewModel> GetAllPaging(string keyword, int page, int pageSize);

        ProductViewModel GetById(int id);

        void ImportExcel(string path, int categoryId);

        void Save();

        void AddQuantity(int productId, List<ProductQuantityViewModel> productQuantities);

        List<ProductQuantityViewModel> GetQuantities(int productId);

        void AddImages(int productId, string[] images);

        List<ProductImageViewModel> GetImages(int productId);

        void AddWholePrice(int productId, List<WholePriceViewModel> wholePriceVm);

        List<WholePriceViewModel> GetWholePrices(int productId);

        List<ProductViewModel> GetLastest(int top);

        List<ProductViewModel> GetHotProduct(int top);

        List<ProductViewModel> GetRelatedProducts(int id, int top);

        List<ProductViewModel> GetUpsellProducts(int top);

        List<TagViewModel> GetProductTags(int productId);

        bool CheckAvailability(int productId, int size, int color);
    }
}
