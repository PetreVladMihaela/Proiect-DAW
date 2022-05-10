using backend_proiect.Entities;
using backend_proiect.Models;

namespace backend_proiect.Managers
{
    public interface ILocationsManager
    {
        Location GetLandmarkLocation(int landmarkId);
        Location GetLocation(int locId);
        List<Location> GetLocations();
        void Create(LocationModel model);
        void Update(LocationModel model);
        void DeleteByLandmarkId(int id);
        void DeleteByLocationId(int id);
    }
}
