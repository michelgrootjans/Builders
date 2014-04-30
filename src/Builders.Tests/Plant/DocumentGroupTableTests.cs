using Builders.Tests.Entities;
using NUnit.Framework;
using Plant.Core;

namespace Builders.Tests.Plant
{
    public class DocumentGroupBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefinePropertiesOf<DocumentGroupTable>(new
            {
                Naam = "My docs",
                DocumentGroupId = 123
            });
        }

    }

    [TestFixture]
    public class DocumentGroupTableTests
    {
        private BasePlant plant;

        [SetUp]
        public void SetUp()
        {
            plant = new BasePlant().WithBlueprintsFromAssemblyOf<DocumentGroupTableTests>();
        }


        [Test]
        public void DefaultBuilder()
        {
            var dgt = plant.Create<DocumentGroupTable>();
            Assert.That(dgt.Naam, Is.EqualTo("My docs"));
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
        }

        [Test]
        public void CustomBuilder()
        {
            var dgt = plant.Create<DocumentGroupTable>(new
            {
                Naam = "My custom docs"
            });
            Assert.That(dgt.Naam, Is.EqualTo("My custom docs"));
            Assert.That(dgt.DocumentGroupId, Is.EqualTo(123));
        }


    }
}