using Database.Models;
using EFT_RabbitMQ.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace EFT_RabbitMQ.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class EftController: ControllerBase
    {
        [HttpPost("send")]
        public IActionResult SendToMoney([FromBody] SendingEftModel model)
        {
            EftProducerHelper.SendMoney(model);
            return Ok("Eft isteğiniz listelenmiştir.");
        }
            
    }
}
