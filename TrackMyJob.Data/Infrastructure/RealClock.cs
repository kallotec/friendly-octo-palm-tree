using TrackMyJob.Domain.Infrastructure;
namespace Forge.Data.Infrastructure;

public class RealClock : IClock
{
    public long GetUtcTicks()
    {
        return DateTime.UtcNow.Ticks;
    }
}