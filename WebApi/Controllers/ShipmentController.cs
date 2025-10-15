using BL.Contract;
using BL.Contract.Shipment;
using BL.Dtos;
using BL.Services;
using DAL.Exceptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ShipmentController : ControllerBase
    {
        IShipmentCommand _shipment;
        IShipmentQuery _shipmentQuery;
        IUserService _userService;
        IShipmentStateHandlerFactory _shipmentStateHandlerFactory;
        public ShipmentController(IShipmentCommand shipment, IShipmentQuery shipmentQuery,
            IUserService userService, IShipmentStateHandlerFactory shipmentStateHandlerFactory)
        {
            _shipment = shipment;
            _userService = userService;
            _shipmentStateHandlerFactory = shipmentStateHandlerFactory;
            _shipmentQuery = shipmentQuery;
        }
        // GET: api/<ShipmentController>
        [HttpGet]
        public async Task<ActionResult<ApiResponse<List<ShippmentDto>>>> Get()
        {
            try
            {
                var data = await _shipmentQuery.GetShipments(); // أو _repo.GetShipments() حسب مكان التنفيذ

                return Ok(ApiResponse<List<ShippmentDto>>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<ShippmentDto>>.FailResponse(
                    "data access exception",
                    new List<string> { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<List<ShippmentDto>>.FailResponse(
                    "general exception",
                    new List<string> { ex.Message }));
            }
        }

        // GET api/<ShipmentController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ApiResponse<ShippmentDto>>> Get(Guid id)
        {
            try
            {
                var data = await _shipmentQuery.GetShipment(id); // أو _repo.GetShipments() حسب مكان التنفيذ

                return Ok(ApiResponse<ShippmentDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<ShippmentDto>.FailResponse(
                    "data access exception",
                    new List<string> { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<ShippmentDto>.FailResponse(
                    "general exception",
                    new List<string> { ex.Message }));
            }
        }

        // POST api/<ShipmentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ShippmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                await _shipment.Create(data);

                return Ok(ApiResponse<object>.SuccessResponse("", "Shipment created successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while creating the shipment.", errors));
            }
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit([FromBody] ShippmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                await _shipment.Edit(data);

                return Ok(ApiResponse<object>.SuccessResponse("", "Shipment created successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while creating the shipment.", errors));
            }
        }

        [HttpPost("ChangeStatus")]
        public async Task<IActionResult> ChangeStatus([FromBody] ShippmentDto data)
        {
            if (data == null)
            {
                return BadRequest(ApiResponse<string>.FailResponse("Shipment data is required."));
            }

            try
            {
                ShipmentStatusEnum targetStatus = (ShipmentStatusEnum)data.CurrentState;

                var result = _shipmentStateHandlerFactory.GetHandler(targetStatus);
                await result.HandleState(data);

                return Ok(ApiResponse<object>.SuccessResponse(result, "Shipment created successfully."));
            }
            catch (Exception ex)
            {
                var errors = new List<string> { ex.Message };
                return StatusCode(500, ApiResponse<string>.FailResponse("An error occurred while creating the shipment.", errors));
            }
        }

        // PUT api/<ShipmentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ShipmentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
