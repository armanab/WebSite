using Microsoft.EntityFrameworkCore.Query;
using Package.Core.Domain.Content;
using Package.Core.DTO.Products;
using Package.Core.PagedList;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Package.Service.Content
{
    public interface IProductService : IService<Product>
    {


        IPagedList<ProductViewModel> GetPagedListViewModel(Expression<Func<Product, bool>> predicate = null,
                                         Func<IQueryable<Product>, IOrderedQueryable<Product>> orderBy = null,
                                         Func<IQueryable<Product>, IIncludableQueryable<Product, object>> include = null,
                                         int pageIndex = 0,
                                         int pageSize = 20,
                                         bool disableTracking = true);
        ProductViewModel GetViewModelById(int id);
    }
}
