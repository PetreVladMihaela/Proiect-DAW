using backend_proiect.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace backend_proiect.Repositories
{
    public class LandmarksRepository : ILandmarksRepository
    {
        private backend_proiectContext db;

        public LandmarksRepository(backend_proiectContext db)
        {
            this.db = db;
        }

        public IQueryable<Landmark> GetAllLandmarksIQueryable()
        {
            var landmarks = db.Landmarks;
            return landmarks;
        }

        public IQueryable<Landmark> GetLandmarksWithLocations()
        {
            var landmarks = GetAllLandmarksIQueryable().Include(x => x.Location);
            return landmarks;
        }

        public void Create(Landmark landmark)
        {
            db.Landmarks.Add(landmark);
            db.SaveChanges();
        }

        public void Update(Landmark landmark)
        {
            db.Landmarks.Update(landmark);
            db.SaveChanges();
        }

        public void Delete(Landmark landmark)
        {
            db.Landmarks.Remove(landmark);
            db.SaveChanges();
        }
        public void AddLandmarkVisitor(LandmarkVisitor newLandmarkVisitor)
        {
            db.LandmarkVisitors.Add(newLandmarkVisitor);
            db.SaveChanges();
        }
    }
}
