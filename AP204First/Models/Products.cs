using System.ComponentModel.DataAnnotations.Schema;

namespace AP204First.Models
{
    public class Products
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        [Column(TypeName ="decimal(7,2)")]
        public decimal Price { get; set; }
        public bool? DisplayStatus { get; set; } 
    }
}
