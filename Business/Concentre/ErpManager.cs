using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Cashing;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concentre
{
    public class ErpManager : IErpService
    {

        IErpDal _erpDal;

        public ErpManager(IErpDal erpDal)
        {
            _erpDal = erpDal;
        }
        
        [ValidationAspect(typeof(ErpValidator))]
        public IResult Add(Erp erp)
        {
            _erpDal.Add( erp ); 
            return new SuccessResult("Added");
        }

        [CacheAspect]
        public IDataResult<List<Erp>> GetAll()
        {
            var result = _erpDal.GetAll();
            return new SuccessDataResult<List<Erp>>(result, "Erps listed.");
        }

        public IDataResult<List<Erp>> GetFilter(string? invoceNo, string? customerNo, DateTime? startDate, DateTime? endDate)
        {
            var result = _erpDal.GetFilter(invoceNo, customerNo, startDate, endDate);

            return new SuccessDataResult<List<Erp>>(result,"Done");
        }

      
    }
}
