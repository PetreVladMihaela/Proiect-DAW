using backend_proiect.Entities;
using backend_proiect.Models;
using backend_proiect.Repositories;

namespace backend_proiect.Managers
{
    public class LandmarksManager : ILandmarksManager
    {
        private readonly ILandmarksRepository landmarksRepository;

        public LandmarksManager(ILandmarksRepository landmarksRepository)
        {
            this.landmarksRepository = landmarksRepository;
        }

        public List<Landmark> GetAllLandmarks()
        {
            return landmarksRepository.GetAllLandmarksIQueryable().ToList();
        }

        public List<Landmark> GetLandmarksByCountryId(int countryId)
        {
            var landmarks = landmarksRepository.GetAllLandmarksIQueryable();
            return landmarks.Where(i => i.CountryId == countryId).ToList();
        }

        public Landmark GetLandmark(int id)
        {
            var landmark = landmarksRepository.GetAllLandmarksIQueryable().FirstOrDefault(x => x.Id == id);
            return landmark;
        }

        public Landmark GetLandmarkWithLocation(int landmarkId)
        {
            var landmarks = landmarksRepository.GetLandmarksWithLocations();
            return landmarks.FirstOrDefault(x => x.Id == landmarkId);
        }

        public List<Landmark> GetCountryLandmarksWithLocations(int countryId)
        {
            var landmarks = landmarksRepository.GetLandmarksWithLocations();
            return landmarks.Where(i => i.CountryId == countryId).ToList();
        }

        public List<string> GetCountryCities(int countryId)
        {
            var landmarks = GetCountryLandmarksWithLocations(countryId);
            List<string> cities = new List<string>();
            foreach (var landmark in landmarks)
            {
                cities.Add(landmark.Location.City);
            }
            return cities;
        }

        public void AddVisitor(LandmarkVisitorModel model)
        {
            var newLandmarkVisitor = new LandmarkVisitor
            {
                LandmarkId = model.LandmarkId,
                VisitorEmail = model.VisitorEmail
            };
            landmarksRepository.AddLandmarkVisitor(newLandmarkVisitor);
        }

        public int Create(LandmarkModel model)
        {
            var newLandmark = new Landmark
            {
                //Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CountryId = model.CountryId
            };
            landmarksRepository.Create(newLandmark);

            return landmarksRepository.GetAllLandmarksIQueryable().Max(l => l.Id);
        }

        public void Delete(int id)
        {
            var landmark = GetLandmark(id);
            landmarksRepository.Delete(landmark);
        }

        public void DeleteAll()
        {
            var landmarks = GetAllLandmarks();
            landmarks.ForEach(l => landmarksRepository.Delete(l));
        }

        public void Update(LandmarkModel model)
        {
            var landmark = GetLandmark(model.Id);
            landmark.Name = model.Name;
            landmark.Description = model.Description;
            landmarksRepository.Update(landmark);
        }
    }
}
