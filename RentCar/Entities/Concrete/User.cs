using RentCar.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace RentCar.Entities
{
    public class User:IEntity
    {
        public virtual int Id { get; set; }
        [Required]
        public virtual string FirstName { get; set; }
        [Required]
        public virtual string SecondName { get; set; }
        [DataType(DataType.Password)]
        public virtual string Password { get; set; }
        [Required]
        [RegularExpression(@"^/\(?([0-9]{3})\)?([ .-]?)([0-9]{3})\2([0-9]{4})/", ErrorMessage = "Phone is not valid.")]
        public virtual string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public virtual string Email { get; set; }
        [Required]
        [Range(100, 500, ErrorMessage = "Please enter correct value")]
        public virtual int Age { get; set; }
        [Required]
        [Range(100, 500, ErrorMessage = "Please enter correct value")]
        public virtual bool DriverLicense { get; set; }
        public virtual int RoleId { get; set; }
        public virtual bool IsDeleted { get; set; }
        public virtual IList<Order> Orders { get; set; }
        public virtual IList<CreditCard> Cards { get; set; }

        public User()
        {
            Orders = new List<Order>();
            Cards = new List<CreditCard>();
        }

    }
}