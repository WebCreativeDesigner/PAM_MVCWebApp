using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PAM_MVCWebApp.Models
{
    public interface ICalculatedDataRepository
    {
        List<CalculatedDataModel> GetAllCalculatedDataRepository();
    }
}
