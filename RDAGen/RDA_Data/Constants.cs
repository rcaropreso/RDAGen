using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RDAGen.RDA_Data
{
    public class Constants
    {
        public enum ActivityStatus
        { 
            NotStarted,
            InProgress,
            Done
        }

        public enum HRType
        { 
            DirectHR,
            IndirectHR
        }
    }
}
