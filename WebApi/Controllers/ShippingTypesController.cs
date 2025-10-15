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
    public class ShippingTypesController : ControllerBase
    {
        private readonly IShippingType _shippingTypes;
        public ShippingTypesController(IShippingType shippingTypes)
        {
            _shippingTypes = shippingTypes;
        }
        // GET: api/<ShippingTypesController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ShippingTypeDto>>>> Get()
        {
            try
            {
                var data = await _shippingTypes.GetAll();

                return Ok(ApiResponse<List<ShippingTypeDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<ShippingTypeDto>>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<ShippingTypeDto>>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }

        }

        // GET api/<ShippingTypesController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShippingTypeDto>>> Get(Guid id)
        {
            try
            {
                var data = await _shippingTypes.GetById(id);

                return Ok(ApiResponse<ShippingTypeDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<ShippingTypeDto>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShippingTypeDto>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }
        }
    }
}
