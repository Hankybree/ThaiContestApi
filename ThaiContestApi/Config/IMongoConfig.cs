﻿namespace ThaiContestApi.Config
{
    public interface IMongoConfig
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
        string ContestCollection { get; set; }
    }
}
