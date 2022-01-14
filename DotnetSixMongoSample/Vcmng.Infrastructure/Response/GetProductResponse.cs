using Vcmng.Infrastructure.Models;

namespace Vcmng.Infrastructure.Response
{
    public class GetProductResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
