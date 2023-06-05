using Core.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Erp : IEntity
    {
        public int Id { get; set; }

        public string InvoicoNo { get; set; }

        public string Adress { get; set; }

        public string CustomerNo { get; set; }

        public decimal GrandTotal { get; set; }

        public string Currency { get; set; }

        public DateTime CreatedDate { get; set; }

        public string CreatedBy { get; set; }

    }
}
