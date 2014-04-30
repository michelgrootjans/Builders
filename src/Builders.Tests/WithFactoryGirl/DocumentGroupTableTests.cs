using Builders.Tests.Entities;
using NUnit.Framework;

namespace Builders.Tests.WithFactoryGirl
{
    [TestFixture]
    public class DocumentGroupTableTests
    {
        [SetUp]
        public void SetUp()
        {
            FactoryGirl.NET.FactoryGirl.ClearFactoryDefinitions();
            FactoryGirl.NET.FactoryGirl.Define(() => new DocumentGroupTable
            {
                DocumentGroupId = 123,
                Naam = "My docs"
            });
        }

        [Test]
        public void DefaultBuilder()
        {
            var dgt = FactoryGirl.NET.FactoryGirl.Build<DocumentGroupTable>();
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
            Assert.That(dgt.Naam, Is.EqualTo("My docs"));
        }

        [Test]
        public void CustomBuilder()
        {
            var dgt = FactoryGirl.NET.FactoryGirl.Build<DocumentGroupTable>(u => u.Naam = "My custom docs");
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
            Assert.That(dgt.Naam, Is.EqualTo("My custom docs"));
        }

    }
}