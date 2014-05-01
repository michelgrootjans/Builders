using Builders.Tests.Entities;
using NUnit.Framework;
using Plant.Core;

namespace Builders.Tests.WithPlant
{
    public class IncrementingCustomerIdBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefineVariationOf<Customer>("with_sequence", new 
            {
                Name = new Sequence<string>(sequenceValue => "Customer " + sequenceValue)
            });
        }
    }

    [TestFixture]
    public class BuilderWithSequences
    {
        private BasePlant plant;

        [SetUp]
        public void SetUp()
        {
            plant = new BasePlant().WithBlueprintsFromAssemblyOf<VariationTests>();
        }

        [Test]
        public void StaticId()
        {
            Assert.That(plant.Create<Customer>().Name, Is.EqualTo("Microsoft"));
            Assert.That(plant.Create<Customer>().Name, Is.EqualTo("Microsoft"));
            Assert.That(plant.Create<Customer>().Name, Is.EqualTo("Microsoft"));
        }

        [Test]
        public void IncrementingId()
        {
            Assert.That(plant.Create<Customer>("with_sequence").Name, Is.EqualTo("Customer 1"));
            Assert.That(plant.Create<Customer>("with_sequence").Name, Is.EqualTo("Customer 3")); // huh?
            Assert.That(plant.Create<Customer>("with_sequence").Name, Is.EqualTo("Customer 5")); // huh?
        }
    }
}