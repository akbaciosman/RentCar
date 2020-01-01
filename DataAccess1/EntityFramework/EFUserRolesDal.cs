using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    public class EFUserRolesDal : EfEntityRepositoryBase<UserRoles, RentCarContext>, IUserRolesDal
    {
    }
}
