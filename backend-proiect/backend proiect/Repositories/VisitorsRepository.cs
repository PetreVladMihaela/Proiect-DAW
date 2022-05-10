using backend_proiect.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend_proiect.Repositories
{
    public class VisitorsRepository : IVisitorsRepository
    {
        private backend_proiectContext db;

        public VisitorsRepository(backend_proiectContext db)
        {
            this.db = db;
        }

        public IQueryable<Visitor> GetAllVisitorsQueryable()
        {
            var visitors = db.Visitors;
            return visitors;
        }

        public IQueryable<LandmarkVisitor> GetLandmarksByVisitorEmail(string email)
        {
            return db.LandmarkVisitors.Where(x => x.VisitorEmail == email).Include(x=>x.Landmark);
        }

        public void Create(Visitor visitor)
        {
            db.Visitors.Add(visitor);
            db.SaveChanges();
        }

        public void Update(Visitor visitor)
        {
            db.Visitors.Update(visitor);
            db.SaveChanges();
        }

        public void Delete(Visitor visitor)
        {
            db.Visitors.Remove(visitor);
            db.SaveChanges();
        }
    }
}
