using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Entities
{
    public class SalesDetails
    {
        public long SalesDetailsId { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }

        public virtual SalesHeader SalesHeaderId { get; set; }

    }
}
