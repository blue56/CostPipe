using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class CostCenter
    {
        public string Name { get; set; }

        public CostCenterOwner Owner {get; set;}

        // Combined cost for this cost center for a given month
        public decimal Amount {get; set;}

        // Percentage of the month cost that are allocated to this cost center
        public decimal Percentage {get; set;}

        public Cost[] Cost {get; set;}
    }
}
