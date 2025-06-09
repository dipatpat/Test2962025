namespace Test09062025.dtos;

public class EventDetailsDto
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public DateTime Date { get; set; }
    public String OrganizerUsername { get; set; } = null!;
    public List<string> Tags { get; set; } = new();
    public List<UserDto> Participants { get; set; } = new();

    public class UserDto
    {
        public int id { get; set; }
        public string username { get; set; } = null!;
    }
    
}