using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BITServices.AppLogs
{
    public class FileLogger : LogBase
    {
        private string filePath = @"log.txt";

        public override void Log(string message)
        {
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine($"[{DateTime.Now}]" + message);
                writer.Close();
            }
        }
    }
}
