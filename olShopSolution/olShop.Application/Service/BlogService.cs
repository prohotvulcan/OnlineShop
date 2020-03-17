using AutoMapper;
using AutoMapper.QueryableExtensions;
using olShop.Application.Interfaces;
using olShop.Application.ViewModels.Blog;
using olShop.Application.ViewModels.Common;
using olShop.Data.Entities;
using olShop.Data.Enums;
using olShop.Infrastructure.Interfaces;
using olShop.Utilities.Constants;
using olShop.Utilities.Dtos;
using olShop.Utilities.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace olShop.Application.Service
{
    public class BlogService : IBlogService
    {
        private readonly IRepository<Blog, int> _blogRepository;
        private readonly IRepository<Tag, string> _tagRepository;
        private readonly IRepository<BlogTag, int> _blogTagRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BlogService(IRepository<Blog, int> blogRepository,
            IRepository<Tag, string> tagRepository,
            IRepository<BlogTag, int> blogTagRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            this._blogRepository = blogRepository;
            this._tagRepository = tagRepository;
            this._blogTagRepository = blogTagRepository;
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public BlogViewModel Add(BlogViewModel blogVm)
        {
            var blog = _mapper.Map<BlogViewModel, Blog>(blogVm);

            if (!string.IsNullOrEmpty(blog.Tags))
            {
                var tags = blog.Tags.Split(',');
                foreach (var t in tags)
                {
                    var tagId = TextHelper.ToUnsignString(t);
                    if (!_tagRepository.FindAll(x => x.Id == tagId).Any())
                    {
                        Tag tag = new Tag
                        {
                            Id = tagId,
                            Name = t,
                            Type = CommonConstants.BlogTag
                        };
                        _tagRepository.Add(tag);
                    }

                    var blogTag = new BlogTag { TagId = tagId };
                    _blogTagRepository.Add(blogTag);
                }
            }
            _blogRepository.Add(blog);
            return blogVm;
        }

        public void Delete(int id)
        {
            _blogRepository.Remove(id);
        }

        public List<BlogViewModel> GetAll()
        {
            return _blogRepository.FindAll(x => x.BlogTags)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public PagedResult<BlogViewModel> GetAllPaging(string keyword, int pageSize, int page)
        {
            var query = _blogRepository.FindAll();
            if (!string.IsNullOrEmpty(keyword))
            {
                query = query.Where(x => x.Name.Contains(keyword));
            }

            int totalRow = query.Count();

            var data = query.OrderByDescending(x => x.DateCreated)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider);

            return new PagedResult<BlogViewModel>
            {
                Results = data.ToList(),
                RowCount = totalRow,
                CurrentPage = page,
                PageSize = pageSize
            };
        }

        public BlogViewModel GetById(int id)
        {
            return _mapper.Map<Blog, BlogViewModel>(_blogRepository.FindById(id));
        }

        public List<BlogViewModel> GetHotProduct(int top)
        {
            return _blogRepository
                .FindAll(x => x.Status == Status.Active && x.HotFlag == true)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<BlogViewModel> GetLastest(int top)
        {
            return _blogRepository
                .FindAll(x => x.Status == Status.Active)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<BlogViewModel> GetList(string keyword)
        {
            var blog = string.IsNullOrEmpty(keyword) ?
                _blogRepository.FindAll()
                    .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider) :
                _blogRepository.FindAll(x => x.Name.Contains(keyword))
                    .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider);

            return blog.ToList();
        }

        public List<string> GetListByName(string name)
        {
            return _blogRepository
                .FindAll(x => x.Status == Status.Active && x.Name.Contains(name))
                .Select(x => x.Name)
                .ToList();
        }

        public List<BlogViewModel> GetListByTag(string tagId, int page, int pageSize, out int totalRow)
        {
            var query = from x in _blogRepository.FindAll()
                        join y in _blogTagRepository.FindAll()
                        on x.Id equals y.BlogId
                        where y.TagId == tagId && x.Status == Status.Active
                        orderby x.DateCreated descending
                        select x;

            totalRow = query.Count();
            query = query.Skip((page - 1) * pageSize).Take(pageSize);

            return query.ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider).ToList();
        }

        public List<BlogViewModel> GetListPaging(int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Active);

            query = sort switch
            {
                "popular" => query.OrderByDescending(x => x.ViewCount),
                _ => query.OrderByDescending(x => x.DateCreated)
            };

            totalRow = query.Count();
            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<TagViewModel> GetListTag(string searchText)
        {
            return _tagRepository
                .FindAll(x => x.Type == CommonConstants.ProductTag && x.Name.Contains(searchText))
                .ProjectTo<TagViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public List<BlogViewModel> GetRelatedBlogs(int id, int top)
        {
            return _blogRepository
                .FindAll(x => x.Status == Status.Active && x.Id != id)
                .OrderByDescending(x => x.DateCreated)
                .Take(top)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public TagViewModel GetTag(string tagId)
        {
            return _mapper.Map<Tag, TagViewModel>(_tagRepository.FindById(tagId));
        }

        public void IncreaseView(int id)
        {
            var blog = _blogRepository.FindById(id);
            if (blog.ViewCount.HasValue)
            {
                blog.ViewCount++;
            }
            else
            {
                blog.ViewCount = 1;
            }
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public List<BlogViewModel> Search(string keyword, int page, int pageSize, string sort, out int totalRow)
        {
            var query = _blogRepository.FindAll(x => x.Status == Status.Active && x.Name.Contains(keyword));

            query = sort switch
            {
                "popular" => query.OrderByDescending(x => x.ViewCount),
                _ => query.OrderByDescending(x => x.DateCreated)
            };

            totalRow = query.Count();

            return query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ProjectTo<BlogViewModel>(_mapper.ConfigurationProvider)
                .ToList();
        }

        public void Update(BlogViewModel blogVm)
        {
            // update blog
            _blogRepository.Update(_mapper.Map<BlogViewModel, Blog>(blogVm));

            // checking update blog tags
            if (!string.IsNullOrEmpty(blogVm.Tags))
            {
                var tags = blogVm.Tags.Split(',');
                foreach (var t in tags)
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
                    _blogTagRepository.RemoveMultiple(_blogTagRepository.FindAll(x => x.BlogId == blogVm.Id).ToList());
                    BlogTag blogTag = new BlogTag
                    {
                        BlogId = blogVm.Id,
                        TagId = tagId
                    };
                    _blogTagRepository.Add(blogTag);
                }
            }
        }
    }
}
