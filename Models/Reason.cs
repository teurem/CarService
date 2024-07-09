using System.ComponentModel.DataAnnotations;

namespace digitization.Models
{
    public class Reason: BaseEntity
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
