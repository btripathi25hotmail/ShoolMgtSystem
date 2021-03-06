using System;
namespace Sms.BusinessObjects
{
    public class BaseBo
    {
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public bool IsActive { get; set; }
        public string CreatedByName { get; set; }
    }
}