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

    public class HouseVariationsBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefineVariationOf<House>("appartment", new { Color = "blue" });
        }
    }

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

    public class VariationTests
    {
        private BasePlant plant;

        [SetUp]
        public void SetUp()
        {
            plant = new BasePlant().WithBlueprintsFromAssemblyOf<VariationTests>();
        }

        [Test]
        public void Variation()
        {
            var house1 = plant.Create<House>();
            var house2 = plant.Create<House>(variation: "appartment");

            Assert.That(house1.Color, Is.EqualTo("red"));
            Assert.That(house2.Color, Is.EqualTo("blue"));
        }
    }
}