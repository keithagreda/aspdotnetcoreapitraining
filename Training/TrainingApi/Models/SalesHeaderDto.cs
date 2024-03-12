using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingApi.Entities;

namespace TrainingApi.Models
{
    public class SalesHeaderDto
    {
        public long SalesHeaderid { get; set; }
        public decimal TotalAmount { get; set; }
        public ICollection<SalesDetails> SalesDetails { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedStamp { get; set; }

    }
}
