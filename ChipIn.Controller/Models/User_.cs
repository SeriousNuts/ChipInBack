namespace ChipIn.Controller.Models
{
    public partial class User_
    {
        public int Id { get; set; }
        public string? Name_ { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Photo { get; set; }
        public virtual ICollection<Member>? members { get; set; }
        public virtual ICollection<Event>? Events { get; set; }
    }
}
