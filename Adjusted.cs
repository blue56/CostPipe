using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class Adjusted
    {
        public decimal Rate { get; set; }
        public string Description {get; set;}

        public decimal Amount {get; set;}
    }
}
