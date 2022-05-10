using backend_proiect.Entities;

namespace backend_proiect.Repositories
{
    public interface IVisitorsRepository
    {
        IQueryable<Visitor> GetAllVisitorsQueryable();
        void Create(Visitor visitor);
        void Update(Visitor visitor);
        void Delete(Visitor visitor);
        IQueryable<LandmarkVisitor> GetLandmarksByVisitorEmail(string email);

    }
}
