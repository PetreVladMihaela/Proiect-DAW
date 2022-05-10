using backend_proiect.Entities;
using backend_proiect.Models;
using backend_proiect.Repositories;

namespace backend_proiect.Managers
{
    public class CountriesManager : ICountriesManager
    {
        private readonly ICountriesRepository countriesRepository;

        public CountriesManager(ICountriesRepository countriesRepository) 
        { 
            this.countriesRepository = countriesRepository;
        }

        public List<Country> GetCountries()
        {
            return countriesRepository.GetCountriesIQueryable().ToList();
        }

        public Country GetCountryById(int id)
        {
            var country = countriesRepository.GetCountriesIQueryable().FirstOrDefault(x => x.Id == id);
            return country;
        }

        public List<Country> GetCountriesWithLandmarks()
        {
            return countriesRepository.GetCountriesWithLandmarks().ToList();
        }

        public void Create(CountryModel model)
        {
            var newCountry = new Country
            {
                //Id = model.Id,
                Name = model.Name
            };
            countriesRepository.Create(newCountry);
        }

        public void Delete(int id)
        {
            var country = GetCountryById(id);
            countriesRepository.Delete(country);
        }

        public void Update(CountryModel model)
        {
            var country = GetCountryById(model.Id);
            country.Name = model.Name;
            countriesRepository.Update(country);
        }


        //public void UpdateCountryLandmarks(int countryId)
        //{
        //    var country = GetCountryById(countryId);
        //    var countriesWithLandmarks = countriesRepository.GetCountriesWithLandmarks();
        //    var countryWithLandmarks = countriesWithLandmarks.FirstOrDefault(x => x.Id == countryId);
        //    country.Landmarks = countryWithLandmarks.Landmarks;
        //    countriesRepository.Update(country);
        //}
    }
}
