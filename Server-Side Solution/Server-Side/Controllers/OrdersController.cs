using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server_Side.DTOs;
using Server_Side.Repository;
using Server_Side.Repository.Contract;
using System.Data.SqlClient;
using System.Data;
using Server_Side.Erorrs;

namespace Server_Side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository)); ;
        }

        [HttpPost]
        public ActionResult<string> CreateOrder(OrdersDTo orders)
        {
            if (HttpContext.Items.TryGetValue("LanguageCode", out var LanguageCode) is false)
                return BadRequest(new ApiResponse(400, "Language code not found in the request."));
            var status = string.Empty;
            try
            {
                status = _orderRepository.AddOrder(orders);
                if(status!= "Success")
                    return BadRequest(new ApiResponse(400, status));
                return Ok(new ApiResponse(200));
                
            }
            catch (Exception ex)
            {
                return BadRequest(new ApiResponse(400, ex.Message));
            }
        }

       

    }
}
