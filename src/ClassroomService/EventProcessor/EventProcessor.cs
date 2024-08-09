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
        }

        public async Task ProcessDeleteEvent(Guid id)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                var entity = await unitOfWork.BuildingRepository.GetById(id);
                unitOfWork.BuildingRepository.Delete(entity);
                await unitOfWork.SaveChanges();
            }
        }

        public async Task ProcessUpdateEvent(BuildingUpdateDto dto)
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();
                unitOfWork.BuildingRepository.Update(_mapper.Map<UniversityBuilding>(dto));
                await unitOfWork.SaveChanges();
            }
        }
    }
}
