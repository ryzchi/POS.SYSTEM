
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POSCommon;

namespace POSDataService
{
    public class POSAccData
    {
        IPOSAccData POSAccountData;
        public POSAccData()
        {
            POSAccountData = new POSInMemoryData();
        }
        public List<POSAccount> GetAllAccounts()
        {
            return POSAccountData.GetAccounts();
        }
    }
}
