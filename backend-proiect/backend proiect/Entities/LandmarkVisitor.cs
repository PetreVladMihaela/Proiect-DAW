namespace backend_proiect.Entities
{
    public class LandmarkVisitor
    {
        public int LandmarkId { get; set; }
        public string VisitorEmail { get; set; } = null!;

        public virtual Landmark? Landmark { get; set; }
        public virtual Visitor? Visitor { get; set; }
    }
}
