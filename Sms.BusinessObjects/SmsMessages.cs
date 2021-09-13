namespace Sms.BusinessObjects
{
    public static class ApplicationMessage
    {
        public const string NoRecordFound = "No Record found";
        public const string SomethingWentWrong = "Something went wrong. Contact to administrator.";
        public const string ModelStateFailed = "Please fill all required values.";
    }
    public class RoleMessage
    {
        public const string InsertMessage = "Role inserted successfully.";
        public const string UpdateMessage = "Role updated successfully.";
        public const string DeleteMessage = "Role deleted successfully."; 
    }
}
