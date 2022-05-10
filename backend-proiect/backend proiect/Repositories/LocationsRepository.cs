using backend_proiect.Entities;

namespace backend_proiect.Repositories
{
    public class LocationsRepository : ILocationsRepository
    {
        private backend_proiectContext db;

        public LocationsRepository(backend_proiectContext db)
        {
            this.db = db;
        }

        public IQueryable<Location> GetAllLocationsIQueryable()
        {
            var locations = db.Locations;
            return locations;
        }

        public void Create(Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }

        public void Update(Location location)
        {
            db.Locations.Update(location);
            db.SaveChanges();
        }

        public void Delete(Location location)
        {
            db.Locations.Remove(location);
            db.SaveChanges();
        }
    }
}
