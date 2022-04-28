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

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _northwindContext
                .Orders
                .Where(x => x.OrderId == id)
                .ProjectTo<OrderView>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync());

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]OrderView orderView)
        {

            var order = _mapper.Map<Orders>(orderView);

            _northwindContext.Attach(order);
            _northwindContext.Entry(order).State = EntityState.Modified;
            
            await _northwindContext.SaveChangesAsync();
            
            return Ok();
        }
    }
}
