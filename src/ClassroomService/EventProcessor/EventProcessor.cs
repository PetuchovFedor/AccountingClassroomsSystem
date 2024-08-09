using AutoMapper;
using ClassroomService.Data.Interfaces;
using ClassroomService.Dtos;
using ClassroomService.Models;

namespace ClassroomService.EventProcessor
{
    public class EventProcessor : IEventProcessor
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly IMapper _mapper;
        public EventProcessor(IServiceScopeFactory scopeFactory, IMapper mapper)
        {
            _scopeFactory = scopeFactory;
            _mapper = mapper;
        }
        public async Task ProcessCreateEvent(BuildingCreateDto dto)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                await unitOfWork.BuildingRepository.Add(_mapper.Map<UniversityBuilding>(dto));
                await unitOfWork.SaveChanges();
            }
            //throw new NotImplementedException();
        }

        public Task ProcessDeleteEvent(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task ProcessUpdateEvent(BuildingUpdateDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
