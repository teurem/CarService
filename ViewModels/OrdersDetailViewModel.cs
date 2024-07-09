using digitization.Models;
using System.ComponentModel.DataAnnotations;

namespace digitization.ViewModels
{
    public class OrdersDetailViewModel
    {
        [Display(Name = "ФИО клиента")]
        public string ClientFIO { get; set; }
        [Display(Name = "Номер телефона клиента")]
        public string ClientPhoneNumber { get; set; }
        [Display(Name = "Марка автомобиля")]
        public string CarBrand { get; set; }
        [Display(Name = "Модель автомобиля")]
        public string CarModel { get; set; }
        [Display(Name = "Инструкция по ремонту")]
        public string RepairInstructions { get; set; }
        [Display(Name = "Сотрудники")]
        public List<string> EmployeesId { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Коментарии")]
        public string? Comment { get; set; }
        [Display(Name = "Запчасти")]
        public string? SpareParts { get; set; }
        [Display(Name = "Когда создан")]
        public DateTime CreatedAt { get; set; }
        [Display(Name = "Механик")]
        public string? Mechanic { get; set; }
        [Display(Name = "Автоэлектрик")]
        public string? AutoElectrician { get; set; }
        [Display(Name = "Ходовщик")]
        public string? Walker { get; set; }
        [Display(Name = "Маляр")]
        public string? Painter { get; set; }
        [Display(Name = "Моторист")]
        public string? Motorist { get; set; }
    }
}
