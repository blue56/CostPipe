using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostPipe
{
    public class Allocation
    {
        public string CostCenter { get; set; }
        public string Service { get; set; }
        public string ResourceId {get; set;}
    }
}
