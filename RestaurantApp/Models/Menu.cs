using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Menu
    {
        public int Id { get; set; }
        [Display(Name = "Наименование")]
        public string Name { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Визуализация")]
        public string Image { get; set; }
        [Display(Name = "Описание")]
        public string Description { get; set; }
        [Display(Name = "Имя Ресторана")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}