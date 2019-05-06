using Package.Core.Domain.Zone;
using Package.EntityFrameworkCore.EF;

namespace Package.Service.Zone
{
    public class CountryService : BaseService<Country>, ICountryService
    {
        private readonly IRepository<Country> Repository;

        public CountryService(IRepository<Country> repository) : base(repository)
        {
            
            Repository = repository;
        }


    }
}
