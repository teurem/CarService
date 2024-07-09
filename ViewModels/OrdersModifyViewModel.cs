using digitization.Models;
using System.ComponentModel.DataAnnotations;

namespace digitization.ViewModels
{
    public class OrdersModifyViewModel
    {
        public long Id { get; set; }
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
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Коментарии")]
        public string? Comment { get; set; }
        [Display(Name = "Механик")]
        public string? MechanicId { get; set; }
        [Display(Name = "Автоэлектрик")]
        public string? AutoElectricianId { get; set; }
        [Display(Name = "Ходовщик")]
        public string? WalkerId { get; set; }
        [Display(Name = "Маляр")]
        public string? PainterId { get; set; }
        [Display(Name = "Моторист")]
        public string? MotoristId { get; set; }
        public bool IsExecutorSelected { get; set; }
    }
}
