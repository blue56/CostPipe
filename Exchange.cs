using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class Exchanged
    {
        public decimal Rate { get; set; }
        public decimal ExchangedAmount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
