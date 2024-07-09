using System.ComponentModel.DataAnnotations;

namespace digitization.Models
{
    public class Point: BaseEntity
    {
        [Display(Name = "Наименование")]
        public string Name { get; set; }
    }
}
