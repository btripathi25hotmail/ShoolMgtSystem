using System;

namespace Sms.App.Models
{
    public class BaseModel
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
    }
}