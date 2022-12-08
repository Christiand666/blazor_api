using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bibliotek_Blazor_API.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int FK_LibraryId { get; set; }

        [ForeignKey("FK_LibraryId")]
        public virtual Library Library { get; set; }
        [NotMapped]
        public bool IsBooked { set; get; }
    }
}
