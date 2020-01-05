using RentCar.Core.Abstract;
using RentCar.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentCar.DataAccess.Abstract
{
    public interface ICarDal: IEntityRepository<Car>
    {
    }
}
