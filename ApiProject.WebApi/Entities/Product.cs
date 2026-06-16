using System.ComponentModel.DataAnnotations.Schema;

namespace ApiProject.WebApi.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
    }
}

