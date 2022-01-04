namespace Moss.StorageApp.Entities
{
    public class Organization : EntityBase
    {
        public string? Name { get; set; }

        public override string ToString() => "\n"+ $"ID: {Id}, Name: {Name}";
    }
}