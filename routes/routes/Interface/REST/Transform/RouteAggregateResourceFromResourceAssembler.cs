using Frock_backend.routes.Domain.Model.Aggregates;
using Frock_backend.routes.Interface.REST.Resources;

namespace Frock_backend.routes.Interface.REST.Transform
{
    public class RouteAggregateResourceFromResourceAssembler
    {
        public static RouteAggregateResource ToResourceFromEntity(RouteAggregate routeAggregate) =>
            new RouteAggregateResource(
                routeAggregate.Id,
                routeAggregate.Price,
                routeAggregate.Frequency,
                routeAggregate.Duration,
                routeAggregate.Stops.Select(stop => new StopInRoutesResource(stop.FkStopId)).ToList(),
                routeAggregate.Schedules.Select(schedule =>
                    new ScheduleResource(schedule.StartTime, schedule.EndTime, schedule.DayOfWeek, schedule.Enabled)).ToList()
            );
    }
}
