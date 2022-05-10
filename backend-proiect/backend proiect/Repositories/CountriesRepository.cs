using backend_proiect.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_proiect.Repositories
{
    public class CountriesRepository : ICountriesRepository
    {
        private backend_proiectContext db;

        public CountriesRepository(backend_proiectContext db)
        {
            this.db = db;
        }

        public IQueryable<Country> GetCountriesIQueryable()
        {
            var countries = db.Countries;
            return countries;
        }

        public IQueryable<Country> GetCountriesWithLandmarks()
        {
            var countries = GetCountriesIQueryable().Include(x => x.Landmarks);
            return countries;
        }

        public void Create(Country country)
        {
            //db.Countries.FromSqlRaw("SET IDENTITY_INSERT dbo.Countries ON;");
            db.Countries.Add(country);
            db.SaveChanges();
        }

        public void Update(Country country)
        {
            db.Countries.Update(country);
            db.SaveChanges();
        }

        public void Delete(Country country)
        {
            db.Countries.Remove(country);
            db.SaveChanges();
        }

    }
}
