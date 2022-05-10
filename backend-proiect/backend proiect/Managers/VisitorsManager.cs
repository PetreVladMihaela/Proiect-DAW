using backend_proiect.Entities;
using backend_proiect.Models;
using backend_proiect.Repositories;

namespace backend_proiect.Managers
{
    public class VisitorsManager : IVisitorsManager
    {
        private readonly IVisitorsRepository visitorsRepository;

        public VisitorsManager(IVisitorsRepository visitorsRepository)
        {
            this.visitorsRepository = visitorsRepository;
        }

        public List<Visitor> GetVisitors()
        {
            return visitorsRepository.GetAllVisitorsQueryable().ToList();
        }

        public Visitor GetVisitorByEmail(string email)
        {
            var visitor = visitorsRepository.GetAllVisitorsQueryable().FirstOrDefault(x => x.Email == email);
            return visitor;
        }

        public List<Landmark> GetVisitedLandmarks(string email)
        {
            List<Landmark> landmarks = new List<Landmark>();
            List<LandmarkVisitor> list = visitorsRepository.GetLandmarksByVisitorEmail(email).ToList();

            foreach (var item in list)
            {
                landmarks.Add(item.Landmark);
            }
            return landmarks;
        }

        public void Delete(string email)
        {
            var visitor = GetVisitorByEmail(email);
            visitorsRepository.Delete(visitor);
        }

        public void Create(VisitorModel model)
        {
            var newVisitor = new Visitor
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                Password = model.Password,
                Role = model.Role
        };
            visitorsRepository.Create(newVisitor);
        }

        public void Update(VisitorModel model)
        {
            var visitor = GetVisitorByEmail(model.Email);
            visitor.FirstName = model.FirstName;
            visitor.FirstName = model.FirstName;
            visitor.Email = model.Email;
            visitor.Password = model.Password;
            visitor.Role = model.Role;
            visitorsRepository.Update(visitor);
        }
    }
}
