using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace pillsSV.Classes
{
    public class cnnStatus
    {
        public bool status()
        {
            if (NetworkInterface.GetIsNetworkAvailable())
                return true;
            else
                return false;
        }
    }
}
