using System;
using EventFlow;
using EventFlow.Configuration;
using Microsoft.Extensions.Configuration;
using Nest;

namespace TimeZebra.Shared.Extensions
{
    public static class ElasticsearchRegister
    {
        public static IEventFlowOptions RegisterElasticsearch(this IEventFlowOptions eventFlowOptions)
        {
            return eventFlowOptions.RegisterServices(sr =>
            {
                sr.Register(f =>
                {
                    var connectionString = f.Resolver.Resolve<IConfiguration>()["elasticsearch"];
                    var connection = new ConnectionSettings(new Uri(connectionString));
                    connection.DisableDirectStreaming(true);
                    IElasticClient elasticClient = new ElasticClient(connection);
                    return elasticClient;
 
                }, Lifetime.Singleton);
                sr.Register<EventFlow.Elasticsearch.ReadStores.IReadModelDescriptionProvider, EventFlow.Elasticsearch.ReadStores.ReadModelDescriptionProvider>(Lifetime.Singleton, true);
            });
        }
    }
}