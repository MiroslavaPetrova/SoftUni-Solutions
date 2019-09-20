namespace MiniORM.App.Data
{
    using Entities;

    public class SoftUniDbContext : DbContext
    {
        public SoftUniDbContext(string connectionString)
            : base(connectionString)
        {
        }

        public DBSet<Employee> Employees { get; }

        public DBSet<Department> Departments { get; }

        public DBSet<Project> Projects { get; }

        public DBSet<EmployeeProject> EmployeesProjects { get; }
    }
}
