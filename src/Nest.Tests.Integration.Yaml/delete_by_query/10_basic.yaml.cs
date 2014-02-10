using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.DeleteByQuery
{
	public partial class DeleteByQuery10BasicYaml10Tests
	{
		
		public class BasicDeleteByQuery10Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public BasicDeleteByQuery10Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void BasicDeleteByQueryTests()
			{

				//do index 
				_body = new {
					foo= "bar"
				};
				this._client.IndexPost("test_1", "test", "1", _body, nv=>nv);

				//do index 
				_body = new {
					foo= "baz"
				};
				this._client.IndexPost("test_1", "test", "2", _body, nv=>nv);

				//do index 
				_body = new {
					foo= "foo"
				};
				this._client.IndexPost("test_1", "test", "3", _body, nv=>nv);

				//do indices.refresh 
				
				this._client.IndicesRefreshGet(nv=>nv);

				//do delete_by_query 
				_body = new {
					match= new {
						foo= "bar"
					}
				};
				this._client.DeleteByQuery("test_1", _body, nv=>nv);

				//do indices.refresh 
				
				this._client.IndicesRefreshGet(nv=>nv);

				//do count 
				
				this._client.CountGet("test_1", nv=>nv);
			}
		}
	}
}
