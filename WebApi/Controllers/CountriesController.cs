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
    public class CountriesController : ControllerBase
    {
        private readonly ICountry _country;
        public CountriesController(ICountry country)
        {
            _country = country;
        }
        // GET: api/<countryController>
        [HttpGet]
        public ActionResult<ApiResponse<List<CountryDto>>> Get()
        {
            try
            {
                var data = _country.GetAll();

                return Ok(ApiResponse<List<CountryDto>>.SuccessResponse(data));
            }
            catch(DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<List<CountryDto>>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch(Exception ex)
            {
                return StatusCode(500, ApiResponse<List<CountryDto>>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }

        }

        // GET api/<countryController>/5
        [HttpGet("{id}")]
        public ActionResult<ApiResponse<CountryDto>> Get(Guid id)
        {
            try
            {
                var data = _country.GetById(id);

                return Ok(ApiResponse<CountryDto>.SuccessResponse(data));
            }
            catch (DataAccessException daEx)
            {
                return StatusCode(500, ApiResponse<CountryDto>.FailResponse
                    ("data access exception", new List<string>() { daEx.Message }));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ApiResponse<CountryDto>.FailResponse
                    ("general exception", new List<string>() { ex.Message }));
            }
        }
    }
}
