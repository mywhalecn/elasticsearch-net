using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.Mget
{
	public partial class Mget60RealtimeRefreshYaml60Tests
	{
		
		public class RealtimeRefresh60Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public RealtimeRefresh60Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void RealtimeRefreshTests()
			{

				//do indices.create 
				_body = new {
					settings= new {
						index= new {
							refresh_interval= "-1",
							number_of_replicas= "0"
						}
					}
				};
				this._client.IndicesCreatePost("test_1", _body, nv=>nv);

				//do cluster.health 
				
				this._client.ClusterHealthGet(nv=>nv);

				//do index 
				_body = new {
					foo= "bar"
				};
				this._client.IndexPost("test_1", "test", "1", _body, nv=>nv);

				//do mget 
				_body = new {
					ids= new [] {
						"1"
					}
				};
				this._client.MgetPost("test_1", "test", _body, nv=>nv);

				//do mget 
				_body = new {
					ids= new [] {
						"1"
					}
				};
				this._client.MgetPost("test_1", "test", _body, nv=>nv);

				//do mget 
				_body = new {
					ids= new [] {
						"1"
					}
				};
				this._client.MgetPost("test_1", "test", _body, nv=>nv);
			}
		}
	}
}
