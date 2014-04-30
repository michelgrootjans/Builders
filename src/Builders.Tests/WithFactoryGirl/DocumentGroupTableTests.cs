using Builders.Tests.Entities;
using NUnit.Framework;
using Builder = FactoryGirl.NET.FactoryGirl; // HACK OM HET MOOI TE MAKEN !!

namespace Builders.Tests.WithFactoryGirl
{
    [TestFixture]
    public class DocumentGroupTableTests
    {
        [SetUp]     
        public void SetUp()
        {
            Builder.ClearFactoryDefinitions();
            Builder.Define(() => new DocumentGroupTable
            {
                DocumentGroupId = 123,
                Name = "My docs"
            });
        }

        [Test]
        public void DefaultBuilder()
        {
            var dgt = Builder.Build<DocumentGroupTable>();
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
            Assert.That(dgt.Name, Is.EqualTo("My docs"));
        }

        [Test]
        public void CustomBuilder()
        {
            var dgt = Builder.Build<DocumentGroupTable>(u => u.Name = "My custom docs");
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
            Assert.That(dgt.Name, Is.EqualTo("My custom docs"));
        }
    }
}