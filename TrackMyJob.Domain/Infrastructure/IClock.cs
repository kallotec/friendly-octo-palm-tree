namespace TrackMyJob.Domain.Infrastructure;

public interface IClock
{
    long GetUtcTicks();
}