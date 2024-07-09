using System.ComponentModel.DataAnnotations;

namespace digitization.ViewModels {
    public class UserCreateViewModel {
        [Required(ErrorMessage = "Email - обязательное поле")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Фамилия - обязательное поле")]
        [Display(Name = "Фамилия")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Имя - обязательное поле")]
        [Display(Name = "Имя")]
        public string Name { get; set; }
        [Display(Name = "Отчество")]
        public string? Patronymic { get; set; }
        [Required(ErrorMessage = "Роль - обязательное поле")]
        [Display(Name = "Роль")]
        public string Role { get; set; }
        [Required(ErrorMessage = "Пароль - обязательное поле")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
    }
}
