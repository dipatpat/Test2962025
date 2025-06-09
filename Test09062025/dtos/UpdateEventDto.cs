using System.ComponentModel.DataAnnotations;
using Test09062025.Models;

namespace Test09062025.dtos;

public class UpdateEventDto
{
    [Required, StringLength(150)] public string Title { get; set; } = null!;
    
    [Required, StringLength(500)] public string Description { get; set; } = null!;

    [Required]
    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
    
   public virtual ICollection<User> Participants { get; set; } = new List<User>();

}
