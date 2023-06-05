using Entities.Concrete;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IErpDal : IEntityRepository<Erp>

    {
        public bool IsUnique(string name);

        List<Erp> GetFilter(string? invoceNo, string? customerNo, DateTime? dateTime, DateTime? endDate);
    }
}
