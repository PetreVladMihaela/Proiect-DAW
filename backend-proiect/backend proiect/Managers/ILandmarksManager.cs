using backend_proiect.Entities;
using backend_proiect.Models;

namespace backend_proiect.Managers
{
    public interface ILandmarksManager
    {
        List<Landmark> GetAllLandmarks();
        List<Landmark> GetLandmarksByCountryId(int countryId);
        Landmark GetLandmark(int id);
        Landmark GetLandmarkWithLocation(int landmarkId);
        List<Landmark> GetCountryLandmarksWithLocations(int countryId);
        List<string> GetCountryCities(int countryId);
        void AddVisitor(LandmarkVisitorModel model);
        int Create(LandmarkModel model);
        void Update(LandmarkModel model);
        void Delete(int id);
        void DeleteAll();
    }
}
