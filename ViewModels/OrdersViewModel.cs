using digitization.Models;
using System.ComponentModel.DataAnnotations;

namespace digitization.ViewModels
{
    public class OrdersViewModel
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
        public List<RoadMapViewModel> RoadMaps { get; set; }
    }
}
