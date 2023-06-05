
using DataAccess.Abstract;
using DataAccess.Concrete;
using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ErpValidator: AbstractValidator<Erp>
    {

        public IErpDal _erpDal;

        public ErpValidator()
        {

            _erpDal = new EfErpDal();

            RuleFor(e => e.InvoicoNo).Length(5).WithMessage("Must be 5 digits");
            RuleFor(e => e.InvoicoNo).Must(BeUnique).WithMessage("Must be unique");
            RuleFor(e => e.Currency).Must(Tl).WithMessage("must be TL");
            RuleFor(e => e.CustomerNo).Must(StartWith).WithMessage("Must Start with C");


        }

        private bool StartWith(string arg)
        {
            throw new NotImplementedException();
        }

        private bool BeUnique(string arg)
        {
           return _erpDal.IsUnique(arg);
        }
       
     
        private bool Tl(string arg)
        {
            return arg.Substring(0, 2) == "C";
        }
    }
}
