using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.AppLogs
{
    public class EventLogger : LogBase
    {
        public override void Log(string message)
        {
            //EventLog eventLog = new EventLog("TestEventLog");
            //eventLog.WriteEntry(message);
        }
    }
}
