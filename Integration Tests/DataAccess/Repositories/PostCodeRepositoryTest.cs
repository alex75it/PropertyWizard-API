using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

using MongoDB.Driver;
using NUnit.Framework;
using Should;

using PropertyWizard.DataAccess.Repositories;
using PropertyWizard.Entities;

namespace PropertyWizard.IntegrationTests.DataAccess.Repositories
{
    [TestFixture, Category("PostCode")]
    public class PostCodeRepositoryTest
    {
        private PostCodeRepository repository;

        private const string DATABASE_NAME = "property_wizard";
        
        [SetUp]
        public void SetUp()
        {
            repository = new PostCodeRepository();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            //DeleteTestRecord();
        }

        [Test]
        public void Create()
        {
            var postCode = new PostCode("code", "description", !default(bool));
            DeleteTestRecord(postCode.Code);

            // Act
            PostCode savedPostCode = repository.Create(postCode);

            Assert.IsNotNull(savedPostCode);
            savedPostCode.Code.ShouldEqual(postCode.Code);
            savedPostCode.Description.ShouldEqual(postCode.Description);
            savedPostCode.Enabled.ShouldEqual(postCode.Enabled);
        }

        [Test]
        public void Create__when__CodeAlreadyExists__should__RaiseAnError()
        {
            var postCode = new PostCode("code", "description", true);
            CreateTestRecord(postCode);

            // Act
            Assert.Throws<MongoWriteException>( () =>
                repository.Create(postCode)
            );
        }

        [Test]
        public void Delete()
        {
            var postCode = new PostCode("code", "description", true);
            CreateTestRecord(postCode);

            // Act
            repository.Delete(postCode.Code);

            postCode = repository.Get(postCode.Code);
            Assert.IsNull(postCode);
        }

        [Test]
        public void List()
        {
            CreateTestRecord(new PostCode("code", "description", !default(bool)));

            // Execute
            var list = repository.List();

            Assert.IsNotNull(list);
            Assert.IsNotEmpty(list);
        }

        [Test]
        public void Get()
        {
            string code = "code" + DateTime.Now.Millisecond;
            string description = "description" + DateTime.Now.Millisecond;
            bool enabled = !default(bool);
            var postCode = new PostCode(code, description, enabled);
            CreateTestRecord(postCode);

            // Act
            postCode = repository.Get(code);

            Assert.IsNotNull(postCode);
            Assert.AreEqual(code, postCode.Code);
            Assert.AreEqual(description, postCode.Description);
            Assert.AreEqual(enabled, postCode.Enabled);
        }


        #region utilities

        private void CreateTestRecord(PostCode postCode)
        {
            DeleteTestRecord(postCode.Code); // clean if exists

            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(DATABASE_NAME)
                .GetCollection<PostCode>(new PostCodeRepository().CollectionName);

            collection.InsertOne(postCode);
        }

        private void DeleteTestRecord(string code)
        {
            var collection = new MongoClient(ConfigurationManager.AppSettings["MongoDB connection string"]).GetDatabase(DATABASE_NAME)
                .GetCollection<PostCode>("postcodes");

            collection.FindOneAndDelete(Builders<PostCode>.Filter.Eq<string>(p => p.Code, code));
        }

        #endregion

    }
}
