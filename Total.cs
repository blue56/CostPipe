using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class Total
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }
}
