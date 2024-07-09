using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace digitization.Models
{
    public class OrdersPointStatus
    {
        [Key, Column(Order = 0)]
        public long OrdersId { get; set; }
        [Key, Column(Order = 1)]
        public string ExecutorId { get; set; }
        public long PointId { get; set; } = 101;
        public byte Order { get; set; }
    }
}
