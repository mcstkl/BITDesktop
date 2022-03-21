using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.AppLogs
{
    public enum LogTarget
    {
        File, Database, EventLog
    }
    public static class LogHelper
    {

        private static LogBase logger = null;
        public static void Log(LogTarget target, string message)
        {
            switch (target)
            {
                case LogTarget.File:
                    logger = new FileLogger();
                    logger.Log(message);
                    break;
                case LogTarget.Database:
                    logger = new DbLogger();
                    break;
                case LogTarget.EventLog:
                    logger = new EventLogger();
                    break;
            }
        }
    }
}
