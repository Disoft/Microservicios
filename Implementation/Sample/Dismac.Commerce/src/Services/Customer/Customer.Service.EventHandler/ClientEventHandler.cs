using Customer.Domain;
using Customer.Persistence.Database;
using Customer.Service.EventHandler.Commands;
using MediatR;

namespace Customer.Service.EventHandlers
{
    public class ClientEventHandler :
        INotificationHandler<ClientCreateCommand>
    {
        private readonly CustomerDbContext _context;

        public ClientEventHandler(
            CustomerDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Client
            {
                Name = notification.Name
            });

            await _context.SaveChangesAsync();
        }
    }
}
