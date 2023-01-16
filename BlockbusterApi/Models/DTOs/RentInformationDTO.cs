using System.ComponentModel.DataAnnotations;

namespace BlockbusterApi.Models.DTOs
{
    public class RentInformationDTO
    {
        [Required]
        public int MovieId { get; set; }
        [Required]
        public string UserId { get; set; }

    }
}
