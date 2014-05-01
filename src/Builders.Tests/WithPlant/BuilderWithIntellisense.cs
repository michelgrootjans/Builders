using Builders.Tests.Entities;
using NUnit.Framework;
using Plant.Core;

namespace Builders.Tests.WithPlant
{
    public class CustomerBlueprint : IBlueprint
    {
        public void SetupPlant(BasePlant p)
        {
            p.DefinePropertiesOf(new Customer
            {
                Name = "Microsoft", 
                Email = "info@microsoft.com"
            });
        }
    }

    [TestFixture]
    public class BuilderWithIntellisense
    {
        private BasePlant plant;

        [SetUp]
        public void SetUp()
        {
            plant = new BasePlant().WithBlueprintsFromAssemblyOf<VariationTests>();
        }

        [Test]
        public void DefaultCreation()
        {
            var customer = plant.Create<Customer>();
            Assert.That(customer.Name, Is.EqualTo("Microsoft"));
            Assert.That(customer.Email, Is.EqualTo("info@microsoft.com"));
        }

        [Test]
        public void CustomCreation()
        {
            var customer = plant.Create(new Customer {Email = "info@apple.com"});
            Assert.That(customer.Name, Is.Null); // watch out for this one
            Assert.That(customer.Email, Is.EqualTo("info@apple.com"));
        }
    }
}