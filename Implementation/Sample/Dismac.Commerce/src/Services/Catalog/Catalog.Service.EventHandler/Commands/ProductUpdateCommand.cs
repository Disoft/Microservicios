using MediatR;

namespace Catalog.Service.EventHandler.Commands
{
    public class ProductUpdateCommand: IRequest<bool>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
