namespace Builders.Tests.Entities
{
    public class Person
    {
        public string Name { get; set; }
        public House House { get; set; }
    }

    public class House
    {
        public string Color { get; set; }
    }
}