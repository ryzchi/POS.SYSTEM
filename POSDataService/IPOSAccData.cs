using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSCommon;

namespace POSDataService
{
    public interface IPOSAccData
    {
        public List<POSAccount> GetAccounts();
    }
}