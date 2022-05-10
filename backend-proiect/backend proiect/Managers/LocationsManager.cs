using backend_proiect.Entities;
using backend_proiect.Models;
using backend_proiect.Repositories;

namespace backend_proiect.Managers
{
    public class LocationsManager : ILocationsManager
    {
        private readonly ILocationsRepository locationsRepository;

        public LocationsManager(ILocationsRepository locationsRepository)
        {
            this.locationsRepository = locationsRepository;
        }

        public List<Location> GetLocations()
        {
            return locationsRepository.GetAllLocationsIQueryable().ToList();
        }

        public Location GetLocation(int locId)
        {
            return locationsRepository.GetAllLocationsIQueryable().FirstOrDefault(x => x.Id == locId);
        }

        public Location GetLandmarkLocation(int landmarkId)
        {
            return locationsRepository.GetAllLocationsIQueryable().FirstOrDefault(x => x.LandmarkId == landmarkId);
        }

        public void Create(LocationModel model)
        {
            var newLoc = new Location
            {
                //Id = model.Id,
                City = model.City,
                Address = model.Address,
                LandmarkId = model.LandmarkId
            };
            locationsRepository.Create(newLoc);
        }

        public void DeleteByLandmarkId(int landmarkId)
        {
            var loc = GetLandmarkLocation(landmarkId);
            locationsRepository.Delete(loc);
        }

        public void DeleteByLocationId(int id)
        {
            var loc = GetLocation(id);
            locationsRepository.Delete(loc);
        }

        public void Update(LocationModel model)
        {
            var loc = GetLandmarkLocation(model.LandmarkId);
            loc.City = model.City;
            loc.Address = model.Address;
            locationsRepository.Update(loc);
        }
    }
}
