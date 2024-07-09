namespace digitization.Models
{
    public class RoadMap: BaseEntity
    {
        public long SourcePointId { get; set; }
        public Point? SourcePoint { get; set; }
        public long TargetPointId { get; set; }
        public Point? TargetPoint { get; set; }
        public long ReasonId { get; set; }
        public Reason Reason { get; set; }
    }
}
