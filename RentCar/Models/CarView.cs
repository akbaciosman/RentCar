using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet;
using System.Web.UI.WebControls;
using System.ComponentModel.DataAnnotations;

namespace RentCar.Models
{
    public class CarView
    {
        [Required]
        public string Brand { get; set; }
        [Required]
        public HttpPostedFileBase Photo { get; set; }
        [Required]
        public bool Available { get; set; }
        public bool IsDeleted { get; set; }
        [Required]
        public double Price { get; set; }
        public Address Address { get; set; }
        public IList<Order> Orders { get; set; }
        
    }
}