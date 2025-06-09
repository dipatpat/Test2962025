using Microsoft.EntityFrameworkCore;
using Test09062025.Models;

namespace Test09062025.repositories;

public class EventRepository : IEventRepository
{
    private readonly MasterContext _context;
   public EventRepository(MasterContext context) => _context = context;

    public async Task<Event?> GetEventWithDetailsAsync(int eventId)
    {
        return await _context.Events
            .Include(e => e.Organizer)
            .Include(e => e.Tags)
            .FirstOrDefaultAsync(e => e.Id == eventId);
    }
    
    public async Task<User?> GetUserByEmailAsync(string email)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task AddUserAsync(User user)
    {
        _context.Users.Add(user);
       await _context.SaveChangesAsync();
    }

    public async Task AddParticipantToEventAsync(int eventId, int userId)
    {
        var eventEntity = await _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
       var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);

        if (eventEntity != null && user != null)
        {
           eventEntity.Users.Add(user);
        }
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
   }
}
