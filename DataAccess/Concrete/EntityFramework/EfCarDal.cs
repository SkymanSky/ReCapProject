using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectDbContext>,ICarDal
    {
        public List<CarDetailDto> GetCarDetails(Expression<Func<CarDetailDto,bool>> filter=null)
        {
            using (ReCapProjectDbContext context=new ReCapProjectDbContext())
            {
                var result = from c in context.Cars
                                                join b in context.Brands on c.BrandId equals b.Id
                                                join clr in context.Colors on c.ColorId equals clr.Id 
                                                
                                                
                                                select new CarDetailDto
                                                {
                                                    Id=c.Id,
                                                    BrandName = b.BrandName,
                                                    ModelName = c.ModelName,
                                                    ColorName = clr.ColorName,
                                                    DailyPrice =c.DailyPrice,
                                                    
                                                };
                return result.ToList();

            }
        }
    }
}
