using System.ComponentModel.DataAnnotations;


namespace RentCar.Entities.HelperConrete
{
    public class Register
    {
        [Required]
        [RegularExpression(@"([a-zA-Z\d]+[\w\d]*|)[a-zA-Z]+[\w\d.]*", ErrorMessage = "Invalid username")]
        public string FirstName { get; set; }
        [Required]
        public string SecondName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }
        [Required]
        [Range(20, 30)]
        public int Age { get; set; }
        [Required]
        public bool DriverLicense { get; set; }
    }
}