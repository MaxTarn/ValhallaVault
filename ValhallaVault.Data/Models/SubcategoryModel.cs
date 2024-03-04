using System.ComponentModel.DataAnnotations;

namespace ValhallaVault.Data.Models
{
    public class SubcategoryModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
