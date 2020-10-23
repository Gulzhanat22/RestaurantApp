using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Restaurant
    {
        
        public int Id { get; set; }
        [Display(Name = "Имя Ресторана")]
        public string Name { get; set; }
        [Display(Name = "Адрес Ресторана")]
        public string Location { get; set; }
        [Display(Name = "Логотип Ресторана")]
        public string Image { get; set; }
        [InverseProperty("Restaurant")]
        public ICollection<UserRole> UserRoles { get; set; }

        [InverseProperty("Restaurant")]
        public ICollection<Menu> Menus { get; set; }
    }
}