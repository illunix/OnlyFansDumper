using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlyFansDumper.Web.Features.Miners
{
    public partial class MinersController : Controller
    {
        private readonly IMediator _mediator;

        [HttpPost]
        public async Task<IActionResult> Add(Add.Command command)
            => Ok(await _mediator.Send(command));
    }
}