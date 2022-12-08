using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace Bibliotek_Blazor_API.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public int FK_UserId { get; set; }

        [ForeignKey("FK_UserId")]
        public virtual User User { get; set; }
        public int FK_BookId { get; set; }

        [ForeignKey("FK_BookId")]
        public virtual Book Book { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity), DataMember]
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get ; set; }
    }
}
