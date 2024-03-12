using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Entities
{
    public class SalesHeader
    {
        public long SalesHeaderid { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<SalesDetails> SalesDetails { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }

    }
}
