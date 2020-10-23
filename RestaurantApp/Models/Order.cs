using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RestaurantApp.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset OrderTime { get; set; }
        public string PaymentType { get; set; }
        public int OrderDetailsId { get; set; }
        public string UserId { get; set; }
        //public Restaurant Restaurant { get;set; }
        public ApplicationUser User { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}