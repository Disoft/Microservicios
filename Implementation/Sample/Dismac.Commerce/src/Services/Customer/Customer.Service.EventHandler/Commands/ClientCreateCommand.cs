using MediatR;

namespace Customer.Service.EventHandler.Commands
{
    public class ClientCreateCommand : INotification
    {
        public string Name { get; set; }
    }
}
