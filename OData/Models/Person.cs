using System.ComponentModel.DataAnnotations;

namespace OData.Models
{
    public class Person : IDataModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}
