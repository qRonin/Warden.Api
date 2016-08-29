﻿using System;
using System.Threading.Tasks;
using MongoDB.Driver;
using Warden.Api.Core.Domain.Wardens;
using Warden.Api.Core.Repositories;
using Warden.Api.Core.Types;
using Warden.Api.Infrastructure.Mongo.Queries;

namespace Warden.Api.Infrastructure.Mongo.Repositories
{
    public class WardenConfigurationRepository : IWardenConfigurationRepository
    {
        private readonly IMongoDatabase _database;

        public WardenConfigurationRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Maybe<WardenConfiguration>> GetAsync(Guid id) 
            => await _database.WardenConfigurations().GetByIdAsync(id);

        public async Task AddAsync(WardenConfiguration configuration)
            => await _database.WardenConfigurations().InsertOneAsync(configuration);
    }
}