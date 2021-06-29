using System;
using System.Linq;
using System.Threading.Tasks;
using GenerateMediator;
using Microsoft.EntityFrameworkCore;
using OnlyFansDumper.Web.Infrastructure.Data;

namespace OnlyFansDumper.Web.Features.Dashboard
{
    [GenerateMediator]
    public static partial class Index
    {
        public sealed partial record Query;

        public record Model(
            int TodayMiners,
            int TotalMiners
        );

        public static async Task<Model> QueryHandler(ApplicationDbContext context)
        {
            var todayMiners = await context.Miners
                .Where(p => p.JoinedAt == DateTime.Today)
                .CountAsync();
            
            var totalMiners = await context.Miners
                .CountAsync();

            return new(
                todayMiners, 
                totalMiners
            );
        }
    }
}