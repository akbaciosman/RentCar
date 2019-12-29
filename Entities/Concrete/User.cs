using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Concrete
{
    public class User :IEntity
    {

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public int RoleId { get; set; }
    }
}