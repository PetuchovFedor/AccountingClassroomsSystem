using AutoMapper;
using ClassroomService.Data.Interfaces;
using ClassroomService.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClassroomService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class UniversityBuildingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UniversityBuildingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<ActionResult<IEnumerable<BuildingReadDto>>> GetAll()
        {
            try
            {
                var result = await _unitOfWork.BuildingRepository.GetAll();
                return Ok(_mapper.Map<IEnumerable<BuildingReadDto>>(result));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
