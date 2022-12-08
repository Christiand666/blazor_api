using System.ComponentModel.DataAnnotations;

namespace Bibliotek_Blazor_API.Models
{
    public class UserToken
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public Guid LoginGuid { get; set; }
    }
}
