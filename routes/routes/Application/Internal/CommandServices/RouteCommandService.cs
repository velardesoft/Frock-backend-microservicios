using Frock_backend.routes.Domain.Model.Aggregates;
using Frock_backend.routes.Domain.Model.Commands;
using Frock_backend.routes.Domain.Repository;
using Frock_backend.routes.Domain.Service;
using Frock_backend.shared.Domain.Repositories;

namespace Frock_backend.routes.Application.Internal.CommandServices
{
    public class RouteCommandService(IRouteRepository routeRepository, IUnitOfWork unitOfWork) : IRouteCommandService
    {
        public async Task<RouteAggregate?> Handle(CreateFullRouteCommand command)
        {
            var newRoute = new RouteAggregate(command); // Solo usa datos del comando propio
            try
            {
                await routeRepository.AddAsync(newRoute);
                await unitOfWork.CompleteAsync();
                return newRoute;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task<RouteAggregate?> Handle(int idRoute, UpdateRouteCommand command)
        {
            var route = await routeRepository.FindByIdAsync(idRoute);
            if (route == null) return null;

            var updatedRoute = new RouteAggregate(command); // Solo datos de routes
            try
            {
                routeRepository.Update(updatedRoute);
                await unitOfWork.CompleteAsync();
                return updatedRoute;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public async Task Handle(DeleteRouteCommand command)
        {
            var route = await routeRepository.FindByIdAsync(command.idRoute);
            if (route == null) return;
            try
            {
                routeRepository.Remove(route);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}