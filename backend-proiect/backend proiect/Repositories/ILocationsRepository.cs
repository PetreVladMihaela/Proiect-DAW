using backend_proiect.Entities;

namespace backend_proiect.Repositories
{
    public interface ILocationsRepository
    {
        IQueryable<Location> GetAllLocationsIQueryable();
        void Create(Location loc);
        void Update(Location loc);
        void Delete(Location loc);
    }
}
