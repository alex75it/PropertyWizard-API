using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using PropertyWizard.DataAccess.Repositories;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    public abstract class RepositoryTestBase<T> where T : IRepository, new()
    {
        protected T repository;
        private const string DATABASE_NAME = "property_wizard";

        [SetUp]
        public void SetUp()
        {
            repository = new T();
        }
    }
}
