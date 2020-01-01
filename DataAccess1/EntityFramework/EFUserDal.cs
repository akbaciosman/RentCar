using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.EntityFramework.Contexts;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.EntityFramework
{
    class EFUserDal : EfEntityRepositoryBase<User, RentCarContext>, IUserDal
    {
    }
}
