using BL.Contract;
using BL.Dtos;
using DAL.Exceptions;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingPackgingController : ControllerBase
    {
        IPackgingTypes _packgingTypes;
        public ShippingPackgingController(IPackgingTypes packgingTypes)
        {
            _packgingTypes = packgingTypes;
        }
        // GET: api/<ShippingTypesController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ShipingPackgingDto>>>> Get()
        {
            try
            {
                var data = await _packgingTypes.GetAll();

                return Ok(ApiResponse<List<ShipingPackgingDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<ShipingPackgingDto>>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<ShipingPackgingDto>>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }

        }

        // GET api/<ShippingTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShipingPackgingDto>>> Get(Guid id)
        {
            try
            {
                var data = await _packgingTypes.GetById(id);

                return Ok(ApiResponse<ShipingPackgingDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<ShipingPackgingDto>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShipingPackgingDto>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }
        }
    }
}
