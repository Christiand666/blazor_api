using System.ComponentModel.DataAnnotations;

namespace Bibliotek_Blazor_API.Models
{
    public class Library
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
    }
}
