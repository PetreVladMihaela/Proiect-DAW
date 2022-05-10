using backend_proiect.Entities;

namespace backend_proiect.Repositories
{
    public interface ILandmarksRepository
    {
        IQueryable<Landmark> GetAllLandmarksIQueryable();
        IQueryable<Landmark> GetLandmarksWithLocations();

        void Create(Landmark landmark);
        void Update(Landmark landmark);
        void Delete(Landmark landmark);
        void AddLandmarkVisitor(LandmarkVisitor newLandmarkVisitor);
    }
}
