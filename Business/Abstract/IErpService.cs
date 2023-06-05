using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IErpService
    {
        IDataResult<List<Erp>> GetAll();
        IResult Add(Erp erp);

        IDataResult<List<Erp>> GetFilter(string? invoceNo, string? customerNo, DateTime? startDate, DateTime? endDate);


    }
}
