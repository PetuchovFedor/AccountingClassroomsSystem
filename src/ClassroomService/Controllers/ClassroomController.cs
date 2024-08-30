using AutoMapper;
using ClassroomService.Data.Interfaces;
using ClassroomService.Dtos;
using ClassroomService.Models;
using ClassroomService.Profiles;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class ClassroomController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClassroomController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<ClassroomReadDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.ClassroomRepository.GetAll();
                return Ok(result.ToList().ConvertAll(item => item.Map()));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(ClassroomCreateDto dto)
        {
            try
            {
                var entity = await _unitOfWork.ClassroomRepository
                    .Add(_mapper.Map<Classroom>(dto));
                await _unitOfWork.SaveChanges();                
                return Ok();
            }
            catch (Exception ex)
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
                var entity = await _unitOfWork.ClassroomRepository.GetById(id);
                _unitOfWork.ClassroomRepository.Delete(entity);
                await _unitOfWork.SaveChanges();
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("update")]
        public async Task<ActionResult> Update(ClassroomUpdateDto dto)
        {
            try
            {
                var entity = await _unitOfWork.ClassroomRepository.GetById(dto.Id);
                entity.Update(dto.Name, dto.Capacity, dto.Number, dto.Floor,
                    dto.ClassroomTypeId, dto.UniversityBuildingId);
                List<ClassroomHasAdditionalField> newFields = [];
                foreach (var item in dto.AdditionalFields)
                {
                    newFields.Add(new ClassroomHasAdditionalField
                    {
                        Value = item.Value,
                        AdditionalFieldId = item.Key,
                        ClassroomId = dto.Id
                    });
                }
                entity.ClassroomHasAdditionalFields = newFields;                
                _unitOfWork.ClassroomRepository.Update(entity);
                await _unitOfWork.SaveChanges();                
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
