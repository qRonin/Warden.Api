﻿using System.Linq;
using Autofac;
using Warden.Api.Filters;
using Warden.Api.Storage;
using Warden.Common.Caching;
using Warden.Common.Security;
using Warden.Common.ServiceClients;

namespace Warden.Api.IoC.Modules
{
    public class StorageModule : Module
    {
        private readonly static string StorageSettingsKey = "storage-settings";
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(x => x.Resolve<ServicesSettings>()
                    .Single(s => s.Title == "storage-service"))
                .Named<ServiceSettings>(StorageSettingsKey)
                .SingleInstance();

            builder.Register(x => new StorageClient(
                    x.Resolve<IServiceClient>(),
                    x.Resolve<ICache>(), 
                    x.Resolve<IFilterResolver>(), 
                    x.Resolve<IServiceAuthenticatorClient>(),
                    x.ResolveNamed<ServiceSettings>(StorageSettingsKey)))
                .As<IStorageClient>()
                .SingleInstance();

            builder.RegisterType<UserStorage>()
                .As<IUserStorage>()
                .SingleInstance();

            builder.RegisterType<ApiKeyStorage>()
                .As<IApiKeyStorage>()
                .SingleInstance();

            builder.RegisterType<OperationStorage>()
                .As<IOperationStorage>()
                .SingleInstance();

            builder.RegisterType<OrganizationStorage>()
                .As<IOrganizationStorage>()
                .SingleInstance();               
        }
    }
}