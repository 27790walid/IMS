using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Model.Models
{
    [Table("Product")]
    public class Product : BaseModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }        
        public string Title { get; set; }
        [StringLength(128)]
        public string Code { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
    }
}
