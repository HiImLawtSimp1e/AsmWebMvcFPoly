using ASM_hungnqph19112_CS4.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_hungnqph19112_CS4.Models
{
    public class ProductDto
    {
        public int Id { get; set; } 
        [Required]
        [StringLength(50), MinLength(5)]
        public string Title { get; set; }
        [Required]
        [StringLength(200), MinLength(5)]
        public string Description { get; set; }
        [StringLength(200), MinLength(5)]
        public string Infomation { get; set; } = "No Information";
        [Required]
        [StringLength(200)]
        public string ImageUrl { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
