using System;
using System.Threading.Tasks;
using GenerateMediator;
using OnlyFansDumper.Web.Features.Miners.Models;
using OnlyFansDumper.Web.Infrastructure.Data;

namespace OnlyFansDumper.Web.Features.Miners
{
    [GenerateMediator]
    public static partial class Add
    {
        public sealed partial record Command;
        
        public static async Task CommandHandler(ApplicationDbContext context)
        {
            var miner = new Miner(DateTime.Today);

            context.Miners
                .Add(miner);

            await context.SaveChangesAsync();
        }
    }
}