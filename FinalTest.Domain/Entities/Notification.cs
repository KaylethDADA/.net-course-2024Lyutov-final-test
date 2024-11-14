namespace FinalTest.Domain.Entities
{
    public class Notification : BaseEntity
    {
        public string Recipient { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; }
    }
}
