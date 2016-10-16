namespace OfficeLogger
{
    public class ConfirmationPopupData
    {
        public ConfirmationType confirmationType { get; set;}
        public string title {get;set;}
        public string message { get; set;}

        public ConfirmationPopupData (ConfirmationType confirmationType, string title, string message)
        {
            this.confirmationType = confirmationType;
            this.title = title;
            this.message = message;
        }
    }
    public enum ConfirmationType
    {
        Error,
        Warning,
        Info
    };
}
