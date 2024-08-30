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
    public class AdditionalFieldController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AdditionalFieldController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<AdditioanalFieldReadDto>>> GetAll() 
        {
            try
            {
                var result = await _unitOfWork.AdditionalFieldRepository.GetAll();
                return Ok(_mapper.Map<IEnumerable<AdditioanalFieldReadDto>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        [Route("create")]
        public async Task<ActionResult> Create(AdditioanalFieldCreateDto dto)
        {
            try
            {
                await _unitOfWork.AdditionalFieldRepository.Add(_mapper.Map<AdditionalField>(dto));
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
