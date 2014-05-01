using Builders.Tests.Entities;
using NUnit.Framework;
using Plant.Core;

namespace Builders.Tests.WithPlant
{
    public class HouseVariationsBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefineVariationOf<House>("appartment", new { Color = "blue" });
        }
    }

    [TestFixture]
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
            var house2 = plant.Create<House>("appartment");

            Assert.That(house1.Color, Is.EqualTo("red"));
            Assert.That(house2.Color, Is.EqualTo("blue"));
        }
    }
}