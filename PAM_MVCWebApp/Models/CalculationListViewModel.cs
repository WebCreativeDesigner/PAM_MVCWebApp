using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM_MVCWebApp.Models
{
    public class CalculatedListViewModel
    {
        public List<decimal> RawData { set; get; }
        public List<decimal> CalculatedData { set; get; }
    }
}
