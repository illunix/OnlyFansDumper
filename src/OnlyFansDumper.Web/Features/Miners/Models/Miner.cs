using System;
using OnlyFansDumper.Web.Infrastructure.Models;

namespace OnlyFansDumper.Web.Features.Miners.Models
{
    public record Miner(DateTime JoinedAt) : BaseEntity;
}