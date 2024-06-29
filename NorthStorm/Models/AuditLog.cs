using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using NuGet.Packaging.Signing;
using static Azure.Core.HttpHeader;

namespace NorthStorm.Models
{
    public class AuditLog
    {
        public int AuditID { get; set; }

        public string UserName { get; set; }
        public DateTime TimeStamp { get; set; }

        public string IPAddress { get; set; }

        public string ActionType { get; set; }

        public string PreviousValue { get; set; }

        public string NewValue { get; set; }

        public int RecordID { get; set; }
        public string RecordName { get; set; }

        public string DeviceID { get; set; }

        public string Note { get; set; }

    }
}
