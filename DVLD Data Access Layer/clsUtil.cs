using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_Data_Access_Layer
{
    public static class clsUtil
    {
        public static void ExceptionLog(string message, EventLogEntryType eventType)
        {
            try
            {
                string sourceName = "DVLD";

                // Create the event source if it does not exist
                if (!EventLog.SourceExists(sourceName))
                {
                    EventLog.CreateEventSource(sourceName, "Application");
                }

                // Log an information event
                EventLog.WriteEntry(sourceName, message, eventType);
            }
            catch (UnauthorizedAccessException ex)
            {
                File.AppendAllText("ErrorLog.txt", $"{DateTime.Now}: {ex.Message}\n");
            }
            catch (Exception ex)
            {
                File.AppendAllText("ErrorLog.txt", $"{DateTime.Now}: {ex.Message}\n");
            }
        }
    }
}
