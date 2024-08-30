using AutoMapper;
using ClassroomService.Data.Interfaces;
using ClassroomService.Dtos;
using ClassroomService.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]

    public class ClassroomTypeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ClassroomTypeController(IUnitOfWork unitOfWork, IMapper mapper) 
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        [Route("classroom-type/{id}")]
        public async Task<ActionResult<ClassroomTypeReadDto>> GetById(Guid id) 
        {
            var entity = await _unitOfWork.ClassromTypeRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClassroomTypeReadDto>(entity));
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<ClassroomTypeReadDto>>> GetAll()
        {
            try
            {
                var types = await _unitOfWork.ClassromTypeRepository.GetAll();
                return Ok(_mapper.Map<IEnumerable<ClassroomTypeReadDto>>(types)); 
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ClassroomTypeReadDto>> Create(ClassroomTypeCreateDto dto)
        {
            try
            {
                var entity = await _unitOfWork.ClassromTypeRepository.Add(_mapper.Map<ClassroomType>(dto));
                await _unitOfWork.SaveChanges();
                return Ok(_mapper.Map<ClassroomTypeReadDto>(entity));
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
                var entity = await _unitOfWork.ClassromTypeRepository.GetById(id);
                _unitOfWork.ClassromTypeRepository.Delete(entity);
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
        public async Task<ActionResult> Update(ClassroomTypeUpdateDto dto)
        {
            try
            {
                var entity = _mapper.Map<ClassroomType>(dto);
                _unitOfWork.ClassromTypeRepository.Update(entity);
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
