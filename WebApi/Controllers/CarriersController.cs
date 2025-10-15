using BL.Contract;
using BL.Dtos;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarriersController : ControllerBase
    {
        ICarrier _cariier;
        public CarriersController(ICarrier carrier)
        {
            _cariier = carrier;
        }
        // GET: api/<countryController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<CarrierDto>>>> Get()
        {
            try
            {
                var data = await _cariier.GetAll();

                return Ok(ApiResponse<List<CarrierDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<CarrierDto>>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<CarrierDto>>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }

        }

        // GET api/<countryController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<CarrierDto>>> Get(Guid id)
        {
            try
            {
                var data = await _cariier.GetById(id);

                return Ok(ApiResponse<CarrierDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<CarrierDto>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<CarrierDto>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }
        }
    }
}
