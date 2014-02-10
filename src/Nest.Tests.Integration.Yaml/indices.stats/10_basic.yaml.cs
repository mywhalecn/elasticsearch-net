using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.IndicesStats
{
	public partial class IndicesStats10BasicYaml10Tests
	{
		
		public class StatsTest10Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public StatsTest10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void StatsTestTests()
			{

				//do indices.stats 
				
				this._client.IndicesStatsGet(nv=>nv);
			}
		}
	}
}
