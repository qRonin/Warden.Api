﻿using System.Threading.Tasks;
using Warden.Common.Events;
using Warden.Common.Events.Organizations;

namespace Warden.Api.Infrastructure.Events.Handlers.Organizations
{
    public class OrganizationCreatedHandler : IEventHandler<OrganizationCreated>
    {
        public async Task HandleAsync(OrganizationCreated @event)
        {
        }
    }
}