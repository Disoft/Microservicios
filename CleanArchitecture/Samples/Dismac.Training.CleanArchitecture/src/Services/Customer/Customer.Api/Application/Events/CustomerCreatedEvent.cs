namespace Customer.Api.Application.Events
{
    public class CustomerCreatedEvent
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }
}
