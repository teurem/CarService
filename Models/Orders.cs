namespace digitization.Models
{
    public class Orders : BaseEntity
    {
        public string ClientFIO { get; set; }
        public string ClientPhoneNumber { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public string RepairInstructions { get; set; }
        public string? MechanicId { get; set; }
        public User? Mechanic { get; set; }
        public string? AutoElectricianId { get; set; }
        public User? AutoElectrician { get; set; }
        public string? WalkerId { get; set; }
        public User? Walker { get; set; }
        public string? PainterId { get; set; }
        public User? Painter { get; set; }
        public string? MotoristId { get; set; }
        public User? Motorist { get; set; }
        public decimal Price { get; set; }
        public string? Comment { get; set; }
        public string? SpareParts { get; set; }
        public long PointId { get; set; } = 101;
        public Point Point { get; set; }
    }
}
