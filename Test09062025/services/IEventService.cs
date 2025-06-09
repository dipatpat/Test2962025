using Test09062025.dtos;

namespace Test09062025.services;

public interface IEventService
{
    Task<EventDetailsDto?> GetEventDetailsAsync(int eventId);
  //  Task<(bool Success, string Error)> UpdateEventAsync(int eventId, UpdateEventDto dto);
}
