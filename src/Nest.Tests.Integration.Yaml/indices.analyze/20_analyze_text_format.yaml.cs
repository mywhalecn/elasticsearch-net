using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nest;
using NUnit.Framework;


namespace Nest.Tests.Integration.Yaml.IndicesAnalyze
{
	public partial class IndicesAnalyze20AnalyzeTextFormatYaml20Tests
	{
		
		public class TextFormat20Tests
		{
			private readonly RawElasticClient _client;
			private object _body;
		
			public TextFormat20Tests()
			{
				var uri = new Uri("http:localhost:9200");
				var settings = new ConnectionSettings(uri, "nest-default-index");
				_client = new RawElasticClient(settings);
			}

			[Test]
			public void TextFormatTests()
			{

				//do indices.analyze 
				
				this._client.IndicesAnalyzeGet(nv=>nv);
			}
		}
	}
}
