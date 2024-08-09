using ClassroomService.Dtos;

namespace ClassroomService.EventProcessor
{
    public interface IEventProcessor
    {
        Task ProcessCreateEvent(BuildingCreateDto dto);
        Task ProcessUpdateEvent(BuildingUpdateDto dto);
        Task ProcessDeleteEvent(Guid id);
    }
}
