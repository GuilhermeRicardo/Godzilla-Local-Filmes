using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlockbusterApi.Models
{


    public class Rental
    {
        [Key()]
        public int Id { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }

        [ForeignKey("UserIdentity")]
        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public DateTime RentDate { get; set; } = DateTime.Now;

    }

}