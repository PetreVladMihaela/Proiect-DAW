using backend_proiect.Entities;
using backend_proiect.Models;

namespace backend_proiect.Managers
{
    public interface IVisitorsManager
    {
        List<Visitor> GetVisitors();
        Visitor GetVisitorByEmail(string email);
        List<Landmark> GetVisitedLandmarks(string email);
        void Create(VisitorModel model);
        void Update(VisitorModel model);
        void Delete(string email);
    }
}
