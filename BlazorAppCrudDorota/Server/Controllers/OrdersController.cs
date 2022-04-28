using AutoMapper;
using AutoMapper.QueryableExtensions;
using BlazorAppCrudDorota.Server.Database;
using BlazorAppCrudDorota.Shared.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorAppCrudDorota.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly NorthwindContext _northwindContext;
        private readonly IMapper _mapper;

        public OrdersController(
            NorthwindContext northwindContext,
            IMapper mapper)
        {
            _northwindContext = northwindContext;
            _mapper = mapper;
        }
        
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await _northwindContext
                .Orders
                .ProjectTo<OrderView>(_mapper.ConfigurationProvider)
                .ToListAsync());
                
        }
    }
}
