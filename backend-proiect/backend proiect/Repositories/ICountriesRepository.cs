using backend_proiect.Entities;

namespace backend_proiect.Repositories
{
    public interface ICountriesRepository
    {
        IQueryable<Country> GetCountriesIQueryable();
        IQueryable<Country> GetCountriesWithLandmarks();

        void Create(Country country);
        void Update(Country country);
        void Delete(Country country);
    }
}
