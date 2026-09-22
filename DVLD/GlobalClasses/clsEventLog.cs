using System;
using System.Diagnostics;

namespace DVLD.GlobalClasses
{
    public static class clsEventLog
    {
        public static string AppSource = "DVLD";
        public static string AppLog = "Application";

        public static void RegistryErrorTo_EventViewer(string ErrorMessage, EventLogEntryType EntryType)
        {
            if (!EventLog.Exists(AppSource))
            {
                EventLog.CreateEventSource(AppSource, AppLog);
            }
            EventLog.WriteEntry(AppSource, ErrorMessage, EntryType);
        }

    }
}
