using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete
{
    public class EfErpDal : EfEntityRepositoryBase<Erp, RecapContext>, IErpDal
    {
        public List<Erp> GetFilter(string? invoceNo, string? customerNo, DateTime? startDate, DateTime? endDate)
        {
            using (RecapContext context = new RecapContext())
            {
      


                var result = from c in context.Erps where invoceNo == c.InvoicoNo ||
                                 customerNo == c.CustomerNo ||
                               startDate <= c.CreatedDate ||
                                 endDate >= c.CreatedDate select c; 

                       
                             
                return result.ToList();

            }
        }

    

        public bool IsUnique(string name)
        {
            using (RecapContext context = new RecapContext())
            {
                return context.Set<Erp>().Where(item => item.InvoicoNo == name).ToList().Count==0;  
            }
              
        }
    }
}
