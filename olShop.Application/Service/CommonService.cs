using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Common;
using olShop.Data.Entities;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Constants;
using System.Collections.Generic;
using System.Linq;

namespace olShop.Application.Service
{
    public class CommonService : ICommonService
    {
        private readonly IRepository<Footer, string> _footerRepository;
        private readonly IRepository<SystemConfig, string> _systemConfigRepository;
        private readonly IRepository<Slide, int> _slideRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommonService(IRepository<Footer, string> footerRepository,
            IRepository<SystemConfig, string> systemConfigRepository,
            IRepository<Slide, int> slideRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._footerRepository = footerRepository;
            this._systemConfigRepository = systemConfigRepository;
            this._slideRepository = slideRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public FooterViewModel GetFooter()
        {
            return _mapper
                .Map<Footer, FooterViewModel>(_footerRepository
                .FindSingle(x => x.Id == CommonConstants.DefaultFooterId));
        }

        public List<SlideViewModel> GetSlides(string groupAlias)
        {
            return _slideRepository
                .FindAll(x => x.Status && x.GroupAlias == groupAlias)
                .ProjectTo<SlideViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public SystemConfigViewModel GetSystemConfig(string code)
        {
            return _mapper
                .Map<SystemConfig, SystemConfigViewModel>(_systemConfigRepository
                .FindSingle(x => x.Id == code));
        }
    }
}
