using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Concrete
{
    public class User :IEntity
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        [Required]
        public string Age { get; set; }
        public int RoleId { get; set; }
    }
}