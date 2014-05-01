using Builders.Tests.Entities;
using NUnit.Framework;
using Plant.Core;

namespace Builders.Tests.WithPlant
{
    public class PersonBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefinePropertiesOf<Person>(new {Name = "my name"});
        }
    } 

    public class HouseBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefinePropertiesOf<House>(new {Color = "red"});
        }
    }

    [TestFixture]
    public class RelationshipTests
    {
        private BasePlant plant;

        [SetUp]
        public void SetUp()
        {
            plant = new BasePlant().WithBlueprintsFromAssemblyOf<RelationshipTests>();
        }

        [Test]
        public void SimpleRelationship()
        {
            var person = plant.Create<Person>();
            Assert.That(person.Name, Is.EqualTo("my name"));
            Assert.That(person.House.Color, Is.EqualTo("red"));
        }
    }
}