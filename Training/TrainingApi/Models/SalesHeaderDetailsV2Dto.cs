using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingApi.Models
{
    public class SalesHeaderDetailsV2Dto
    {
        public long SalesHeaderid { get; set; }
        public decimal TotalAmount { get; set; }
        public long Quantity { get; set; }
        public decimal Price { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }
    }
}
