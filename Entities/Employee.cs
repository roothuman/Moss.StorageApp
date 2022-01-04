namespace Moss.StorageApp.Entities
{
   public class Employee: EntityBase
    {
        public string? FirstName { get; set; }
        public override string ToString() => "\n" + $"ID: {Id}, First Name: {FirstName}";

    }
}
