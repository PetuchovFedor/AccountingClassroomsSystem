using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniversityBuildingService.Data;
using UniversityBuildingService.Dtos;
using UniversityBuildingService.MessageBusClient;
using UniversityBuildingService.Models;

namespace UniversityBuildingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UniversityBuildingController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUniversityBuildingRepository _repository;
        private readonly IMessageBusClient _messageSender;
        public UniversityBuildingController(IMapper mapper, IUniversityBuildingRepository repository,
            IMessageBusClient messageSender)
        {
            _mapper = mapper;
            _repository = repository;
            _messageSender = messageSender;
        }

        [HttpGet]
        [Route("building/{id}")]
        public async Task<ActionResult<BuildingReadDto>> GetById(Guid id) 
        {
            var entity = await _repository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            var dto = _mapper.Map<BuildingReadDto>(entity);
            return Ok(dto);
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<BuildingReadDto>> CreateBuilding(BuildingCreateDto dto)
        {
            try
            {
                var building = _mapper.Map<UniversityBuilding>(dto);
                building = await _repository.Add(building);
                await _repository.SaveShanges();
                _messageSender.SendMessage("university_building_exchange", "add_route", building);
                return Ok(_mapper.Map<BuildingReadDto>(building));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(BuildingUpdateDto dto)
        {
            try
            {
                var building = _mapper.Map<UniversityBuilding>(dto);
                _repository.Update(building);
                await _repository.SaveShanges();
                return Ok();
            }            
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var entity = await _repository.GetById(id);
                if (entity == null)
                {
                    return NotFound();
                }
                _repository.Delete(entity);
                await _repository.SaveShanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
