using System.ComponentModel.DataAnnotations;

namespace ApiProjectKampi.WebApi.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public List<Product> Products{ get; set; }
    }
}
