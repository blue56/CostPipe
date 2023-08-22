using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class CostReport
    {
        public CostReport()
        {
            Version = "1.0";
        }

        public string Version {get; set;}
        public Cost[] Cost {get; set;}
        public CostCenter[] CostCenters {get; set;}
        public decimal TotalAmount {get; set;}
    }
}
