﻿using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Api.Models.Entity;

namespace Api.Config.Mongo;

public class MongoConfig : IMongoConfig
{
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    private readonly IMongoCollection<Contest> _contestColletion;

    public MongoConfig(IMongoSettings mongoSettings)
    {
        ConventionPack conventionPack = new() { new CamelCaseElementNameConvention() };
        ConventionRegistry.Register("camelCase", conventionPack, t => true);

        _client = new MongoClient(mongoSettings.ConnectionString);
        _database = _client.GetDatabase(mongoSettings.DatabaseName);

        _contestColletion = _database.GetCollection<Contest>(mongoSettings.ContestCollection);
    }

    public IMongoCollection<Contest> ContestCollection => _contestColletion;
}
