﻿using System;
using System.Collections.Generic;
using System.Linq;
using Nest.Tests.MockData;
using Nest.Tests.MockData.Domain;
using NUnit.Framework;

namespace Nest.Tests.Integration.Core.Get
{
	[TestFixture]
	public class GetTests : IntegrationTests
	{
		[Test]
		public void SimpleGet()
		{
			var elasticSearchProject = this._client.Source<ElasticSearchProject>(4);
			
			Assert.NotNull(elasticSearchProject);
			Assert.IsNotNullOrEmpty(elasticSearchProject.Name);
		}
		[Test]
		public void SimpleMultiGet()
		{
			var elasticSearchProjects = this._client.SourceMany<ElasticSearchProject>(new [] { 4, 5 });

			Assert.NotNull(elasticSearchProjects);
			Assert.IsNotEmpty(elasticSearchProjects);
			foreach (var e in elasticSearchProjects)
			{
				Assert.IsNotNullOrEmpty(e.Name);
			}
		}
		[Test]
		public void GetWithFields()
		{
			var elasticSearchProject = this._client.SourceFields<ElasticSearchProject>(g=>g
				.Id(4)
				.Fields(f=>f.Name)
			);

			Assert.NotNull(elasticSearchProject);
			Assert.IsNotNullOrEmpty(elasticSearchProject.FieldValue(p=>p.Name));
		}
		[Test]
		public void GetWithFieldsDeep()
		{
			var fieldSelection = this._client.Get<ElasticSearchProject>(g => g
				.Id(4)
				.Fields(f => f.Name, f => f.Followers.First().FirstName)
			).Fields;

			Assert.NotNull(fieldSelection);
			Assert.IsNull(fieldSelection.Document);
			var name = fieldSelection.FieldValue(f => f.Name);
			Assert.IsNotNullOrEmpty(name);
			var list = fieldSelection.FieldValue<List<string>>(f=>f.Followers.First().FirstName);
			Assert.NotNull(list);
			Assert.IsNotEmpty(list);
			var array = fieldSelection.FieldValue<string[]>(f => f.Followers.First().FirstName);
			Assert.NotNull(array);
			Assert.IsNotEmpty(array);
			var enumerable = fieldSelection.FieldValue<IEnumerable<string>>(f => f.Followers.First().FirstName);
			Assert.NotNull(enumerable);
			Assert.IsNotEmpty(enumerable);
		}
	}
}
