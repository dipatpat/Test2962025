using Test09062025.dtos;
using Test09062025.Models;
using Test09062025.repositories;

namespace Test09062025.services;

public class EventService : IEventService
{
  private readonly IEventRepository _repo;
    public EventService(IEventRepository repo) => _repo = repo;

    public async Task<EventDetailsDto?> GetEventDetailsAsync(int eventId)
   {
        var ev = await _repo.GetEventWithDetailsAsync(eventId);
        if (ev == null) return null;

        return new EventDetailsDto
        {
            Title = ev.Title,
           Description = ev.Description,
         Date = ev.Date,
            
           OrganizerUsername = ev.Organizer.Username,
           Tags = ev.Tags.Select(t => t.Name).ToList(),
           Participants = ev.Users.Select(u => new EventDetailsDto.UserDto
           {
             id = u.Id,
             username = u.Email
            }).ToList()
       };
    }

   public async Task<(bool Success, string Error)> UpdateEventAsync(int eventId, UpdateEventDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Title) || string.IsNullOrWhiteSpace(dto.Description))
           return (false, "Title, description and email are required.");

        var exists = await _repo.GetEventWithDetailsAsync(eventId);
       if (exists == null)
            return (false, "There is no event with this ID.");

       /// var user = await _repo.GetUserByEmailAsync(dto.Email);

        //if (user == null)
        //{
           // user = new User { Username = dto.Username, Email = dto.Email };
            //await _repo.AddUserAsync(user);
        //}

        //await _repo.AddParticipantToEventAsync(eventId, user.Id);
        //await _repo.SaveChangesAsync();

        return (true, "");
    }
}
