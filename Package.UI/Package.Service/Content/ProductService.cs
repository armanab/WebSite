using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Package.Core.Domain.Content;
using Package.Core.DTO.Products;
using Package.Core.PagedList;
using Package.EntityFrameworkCore.EF;

namespace Package.Service.Content
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IRepository<Product> ProductRepository;
        private readonly IMapper mapper;


        public ProductService(IMapper _mapper, IRepository<Product> productRepository) : base(productRepository)
        {
            ProductRepository = productRepository;
            mapper = _mapper;

        }

        public IPagedList<ProductViewModel> GetPagedListViewModel(Expression<Func<Product, bool>> predicate = null, Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null, Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null, int pageIndex = 0, int pageSize = 20, bool disableTracking = true)
        {
            var pagedList = Repository.GetPagedList(predicate, orderBy, include, pageIndex, pageSize, disableTracking);
            var sds = pagedList.Items.AsEnumerable();
            var result = PagedList.From(pagedList, mapper.Map<IEnumerable<ProductViewModel>>);
            return result;
        }
        public ProductViewModel GetViewModelById(int id)
        {
            ProductViewModel result = new ProductViewModel();
            Product _model = GetById(id);
            result = mapper.Map<ProductViewModel>(_model);
            return result;
        }


    }
}
