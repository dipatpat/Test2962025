using Test09062025.Models;

namespace Test09062025.repositories;

public interface IEventRepository
{
    Task<Event?> GetEventWithDetailsAsync(int eventId);
    
    Task SaveChangesAsync();
}