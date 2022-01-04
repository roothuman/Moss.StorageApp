using System;
using Moss.StorageApp.Data;
using Moss.StorageApp.Entities;
using Moss.StorageApp.Repositories;


namespace Moss.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            GetEmployeeById(employeeRepository);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            WriteAllToConsole(organizationRepository);

            Console.ReadLine();
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee e)
        {
            Console.WriteLine($"Employee Added => {e.FirstName}");
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var dreadManager = new Manager {FirstName = "Dread"};
            var dreadManagerCopy = dreadManager.Copy();
            managerRepository.Add(dreadManager);

            if (dreadManagerCopy is not null)
            {
                dreadManagerCopy.FirstName += "_Copy";
                managerRepository.Add(dreadManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "Ene" });
            managerRepository.Save();
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine("\n" + $"Employee with ID 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee {FirstName = "Moss"},
                new Employee {FirstName = "Edd"},
                new Employee {FirstName = "Vee"}
            };
            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization {Name = "Swift Networks"},
                new Organization {Name = "Hybrid Corps"}
            };
            organizationRepository.AddBatch(organizations);
        }
    }
}
