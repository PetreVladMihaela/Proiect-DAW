using backend_proiect.Entities;
using backend_proiect.Models;

namespace backend_proiect.Managers
{
    public interface ICountriesManager
    {
        List<Country> GetCountries();
        Country GetCountryById(int id);
        public List<Country> GetCountriesWithLandmarks();

        void Create(CountryModel model);
        void Update(CountryModel model);
        //void UpdateCountryLandmarks(int countryId);
        void Delete(int id);
    }
}
