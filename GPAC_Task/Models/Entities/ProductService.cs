using System.ComponentModel.DataAnnotations;

namespace GPAC_Task.Models.Entities
{
    public class ProductService
    {
        [Key]
        public int Id { get; set; }

        public required string Name { get; set; }

        public required string Unit { get; set; }
    }
}
