using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlyFansDumper.Web.Features.Dashboard
{
    public partial class DashboardController : Controller
    {
        private readonly IMediator _mediator;

        public async Task<IActionResult> Index(Index.Query query)
            => View(await _mediator.Send(query));
    }
}