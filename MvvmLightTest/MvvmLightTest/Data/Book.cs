namespace MvvmLightTest.Data
{
    public class Book : IEntity
    {
        public int Id { get; protected set; }

        public string Author { get; set; }

        public string Name { get; set; }
    }
}