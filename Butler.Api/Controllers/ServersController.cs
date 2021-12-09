using Butler.Aplication.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Butler.Api.Controllers
{
    [Route("api/servers")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private IMediator _mediator;

        public ServersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{serverId}/connect")]
        public async Task<IActionResult> Connect(string serverId)
        {
            var res = await _mediator.Send(new ConnectToServerCommand { ServerId = ulong.Parse(serverId) });
            if (!res.Success)
                return BadRequest(res.Message);
            return Ok();
        }

        [HttpPost("{serverId}/disconnect")]
        public async Task<IActionResult> Disconnect(string serverId)
        {
            var res = await _mediator.Send(new DisconnectFromServerCommand { ServerId = ulong.Parse(serverId) });
            if (!res.Success)
                return BadRequest(res.Message);
            return Ok();
        }
    }
}