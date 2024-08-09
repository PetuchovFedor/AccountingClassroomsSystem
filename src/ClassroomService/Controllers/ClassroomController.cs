using AutoMapper;
using ClassroomService.Data.Interfaces;
using ClassroomService.Dtos;
using ClassroomService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [Route("classroom/{id}")]
        public async Task<ActionResult<ClassroomReadDto>> GetById(Guid id)
        {
            var entity = await _unitOfWork.ClassroomRepository.GetById(id);
            if (entity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ClassroomReadDto>(entity));
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<ClassroomReadDto>> Create(ClassroomCreateDto dto)
        {
            try
            {
                var entity = await _unitOfWork.ClassroomRepository
                    .Add(_mapper.Map<Classroom>(dto));
                await _unitOfWork.SaveChanges();
                return Ok(_mapper.Map<ClassroomReadDto>(entity));

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
                var entity = _mapper.Map<Classroom>(dto);
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
