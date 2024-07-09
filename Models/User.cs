using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace digitization.Models
{
    public class User: IdentityUser
    {
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }
        public List<Orders> Orders { get; set; }
    }
}
