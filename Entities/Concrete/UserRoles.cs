using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Entities.Concrete
{
    public class UserRoles:IEntity
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int UserId { get; set; }
    }
}