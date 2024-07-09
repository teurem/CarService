using System.ComponentModel.DataAnnotations;

namespace digitization.ViewModels
{
    public class MovementViewModel
    {
        public string? UserId { get; set; }
        [Display(Name = "Сотрудник")]
        public string? User { get; set; }
        [Display(Name = "Запчасти")]
        public string? SpareParts { get; set; }

        public bool IsAdmin { get; set; }
        public bool IsAddSpareParts { get; set; }
        public long EntityId { get; set; }
        public long RoadMapId { get; set; }
    }
}
