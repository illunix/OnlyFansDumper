using System;

namespace OnlyFansDumper.Web.Infrastructure.Models
{
    public record BaseEntity
    {
        public Guid Id { get; init; }
    }
}