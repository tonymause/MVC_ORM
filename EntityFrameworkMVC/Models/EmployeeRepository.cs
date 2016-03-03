using System.Collections.Generic;
using System.Linq;

namespace EntityFrameworkMVC.Models
{
    public class EmployeeRepository
    {
        private LocalDatabaseEntities _context;

        public EmployeeRepository(LocalDatabaseEntities context)
        {
            _context = context;
        }

        public List<Employee> All()
        {
            return _context.Employees.ToList();
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public Employee Get(int id)
        {
            return _context.Employees.FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var employee = _context.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }
    }
}