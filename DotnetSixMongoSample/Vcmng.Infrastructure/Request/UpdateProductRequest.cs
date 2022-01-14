using System.ComponentModel.DataAnnotations;

namespace Vcmng.Infrastructure.Request
{
    public class UpdateProductRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string CategoryId { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Currency { get; set; }
    }
}
