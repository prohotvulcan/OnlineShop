using AutoMapper;
using AutoMapper.QueryableExtensions;
using OfficeOpenXml;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Common;
using olShop.Application.ViewModels.Product;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Constants;
using olShop.Utilities.Dtos;
using olShop.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace olShop.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product, int> _productRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<ProductTag, int> _productTagRepository;
        private readonly IRepository<ProductQuantity, int> _productQuantityRepository;
        private readonly IRepository<ProductImage, int> _productImageRepository;
        private readonly IRepository<WholePrice, int> _wholePriceRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IRepository<Product, int> productRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<ProductTag, int> productTagRepository,
            IRepository<ProductQuantity, int> productQuantityRepository,
            IRepository<ProductImage, int> productImageRepository,
            IRepository<WholePrice, int> wholePriceRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._productRepository = productRepository;
            this._tagRepository = tagRepository;
            this._productTagRepository = productTagRepository;
            this._productQuantityRepository = productQuantityRepository;
            this._productImageRepository = productImageRepository;
            this._wholePriceRepository = wholePriceRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public ProductViewModel Add(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();
            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (var t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        _tagRepository.Add(new Tag { Id = tagId, Name = t, Type = CommonConstants.ProductTag });
                    }

                    productTags.Add(new ProductTag { TagId = tagId });
                }
            }

            var product = _mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }

            _productRepository.Add(product);
            return productVm;
        }

        public void AddImages(int productId, string[] images)
        {
            _productImageRepository
                .RemoveMultiple(_productImageRepository
                .FindAll(x => x.ProductId == productId)
                .ToList());

            foreach (var img in images)
            {
                _productImageRepository.Add(new ProductImage
                {
                    Path = img,
                    ProductId = productId,
                    Caption = string.Empty
                });
            }
        }

        public void AddQuantity(int productId, List<ProductQuantityViewModel> productQuantities)
        {
            _productQuantityRepository
                .RemoveMultiple(_productQuantityRepository
                .FindAll(x => x.ProductId == productId)
                .ToList());

            foreach (var qty in productQuantities)
            {
                _productQuantityRepository.Add(new ProductQuantity
                {
                    ProductId = productId,
                    ColorId = qty.ColorId,
                    SizeId = qty.SizeId,
                    Quantity = qty.Quantity
                });
            }
        }

        public void AddWholePrice(int productId, List<WholePriceViewModel> wholePriceVm)
        {
            _wholePriceRepository
                .RemoveMultiple(_wholePriceRepository
                .FindAll(x => x.ProductId == productId)
                .ToList());

            foreach (var wp in wholePriceVm)
            {
                _wholePriceRepository.Add(new WholePrice
                {
                    ProductId = productId,
                    FromQuantity = wp.FromQuantity,
                    ToQuantity = wp.ToQuantity,
                    Price = wp.Price
                });
            }
        }

        public bool CheckAvailability(int productId, int size, int color)
        {
            var qty = _productQuantityRepository
                .FindSingle(x => x.ProductId == productId && x.SizeId == size && x.ColorId == color);

            if (qty == null)
            {
                return false;
            }
            return qty.Quantity > 0;
        }

        public void Delete(int id)
        {
            _productRepository.Remove(id);
        }

        public List<ProductViewModel> GetAll()
        {
            return _productRepository
                .FindAll(x => x.ProductCategory)
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public PagedResult<ProductViewModel> GetAllPaging(int? categoryId, string keyword, int page, int pageSize)
        {
            var query = _productRepository.FindAll(x => x.Status == Status.Active);
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            if (categoryId.HasValue)
            {
                query = query.Where(x => x.CategoryId == categoryId.Value);
            }

            int totalRow = query.Count();
            var data = query
                .OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);

            return new PagedResult<ProductViewModel>
            {
                Results = data.ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider).ToList(),
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public ProductViewModel GetById(int id)
        {
            return _mapper.Map<Product, ProductViewModel>(_productRepository.FindById(id));
        }

        public List<ProductViewModel> GetHotProduct(int top)
        {
            return _productRepository
                .FindAll(x => x.HotFlag == true && x.Status == Status.Active)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductImageViewModel> GetImages(int productId)
        {
            return _productImageRepository
                .FindAll(x => x.ProductId == productId)
                .ProjectTo<ProductImageViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductViewModel> GetLastest(int top)
        {
            return _productRepository
                .FindAll(x => x.Status == Status.Active)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<TagViewModel> GetProductTags(int productId)
        {
            var tags = _tagRepository.FindAll();
            var productTags = _productTagRepository.FindAll();

            var query = from x in tags
                        join y in productTags
                        on x.Id equals y.TagId
                        where y.ProductId == productId
                        select new TagViewModel
                        {
                            Id = x.Id,
                            Name = x.Name
                        };
            return query.ToList();
        }

        public List<ProductQuantityViewModel> GetQuantities(int productId)
        {
            return _productQuantityRepository
                .FindAll(x => x.ProductId == productId)
                .ProjectTo<ProductQuantityViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductViewModel> GetRelatedProducts(int id, int top)
        {
            var product = _productRepository.FindById(id);
            return _productRepository
                .FindAll(x => x.Status == Status.Active && x.Id != id && x.CategoryId == product.CategoryId)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<ProductViewModel> GetUpsellProducts(int top)
        {
            return _productRepository
                .FindAll(x => x.PromotionPrice != null)
                .OrderByDescending(x => x.DateModified)
                .Take(top)
                .ProjectTo<ProductViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<WholePriceViewModel> GetWholePrices(int productId)
        {
            return _wholePriceRepository
                .FindAll(x => x.ProductId == productId)
                .ProjectTo<WholePriceViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public void ImportExcel(string path, int categoryId)
        {
            using (var package = new ExcelPackage(new FileInfo(path)))
            {
                ExcelWorksheet workSheet = package.Workbook.Worksheets[1];
                Product product;
                for (int i = workSheet.Dimension.Start.Row + 1; i <= workSheet.Dimension.End.Row; i++)
                {
                    product = new Product();
                    product.CategoryId = categoryId;

                    product.Name = workSheet.Cells[i, 1].Value.ToString();

                    product.Description = workSheet.Cells[i, 2].Value.ToString();

                    decimal.TryParse(workSheet.Cells[i, 3].Value.ToString(), out var originalPrice);
                    product.OriginalPrice = originalPrice;

                    decimal.TryParse(workSheet.Cells[i, 4].Value.ToString(), out var price);
                    product.Price = price;
                    decimal.TryParse(workSheet.Cells[i, 5].Value.ToString(), out var promotionPrice);

                    product.PromotionPrice = promotionPrice;
                    product.Content = workSheet.Cells[i, 6].Value.ToString();
                    product.SeoKeywords = workSheet.Cells[i, 7].Value.ToString();

                    product.SeoDescription = workSheet.Cells[i, 8].Value.ToString();
                    bool.TryParse(workSheet.Cells[i, 9].Value.ToString(), out var hotFlag);

                    product.HotFlag = hotFlag;
                    bool.TryParse(workSheet.Cells[i, 10].Value.ToString(), out var homeFlag);
                    product.HomeFlag = homeFlag;

                    product.Status = Status.Active;

                    _productRepository.Add(product);
                }
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(ProductViewModel productVm)
        {
            List<ProductTag> productTags = new List<ProductTag>();

            if (!string.IsNullOrEmpty(productVm.Tags))
            {
                string[] tags = productVm.Tags.Split(',');
                foreach (string t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag 
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.ProductTag
                        };
                        _tagRepository.Add(tag);
                    }
                    _productTagRepository.RemoveMultiple(_productTagRepository.FindAll(x => x.Id == productVm.Id).ToList());
                    ProductTag productTag = new ProductTag
                    {
                        TagId = tagId
                    };
                    productTags.Add(productTag);
                }
            }

            var product = _mapper.Map<ProductViewModel, Product>(productVm);
            foreach (var productTag in productTags)
            {
                product.ProductTags.Add(productTag);
            }
            _productRepository.Update(product);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
