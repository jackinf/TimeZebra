using EventFlow;
using EventFlow.Configuration;
using EventFlow.Elasticsearch.Extensions;
using EventFlow.Extensions;
using TimeZebra.Shared.Extensions;

namespace TimeZebra.TimeManagement.ReadModel.ElasticSearch
{
    public class ElasticsearchReadModelModule : IModule
    {
        public void Register(IEventFlowOptions eventFlowOptions)
        {
            eventFlowOptions
                .RegisterElasticsearch()
                .AddDefaults(typeof(ElasticsearchReadModelModule).Assembly)
                .RegisterServices(r=>r.Register<TimeManagementReadModelIndexer, TimeManagementReadModelIndexer>())
                .UseElasticsearchReadModel<TimeManagementReadModel>();
        }
    }
}