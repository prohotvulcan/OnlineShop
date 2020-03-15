using olShop.Application.ViewModels.Common;
using System.Collections.Generic;

namespace olShop.Application.Interfaces
{
    public interface ICommonService
    {
        FooterViewModel GetFooter();

        List<SlideViewModel> GetSlides(string groupAlias);

        SystemConfigViewModel GetSystemConfig(string code);
    }
}
