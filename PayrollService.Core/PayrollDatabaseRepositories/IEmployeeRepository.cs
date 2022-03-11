using PayrollService.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PayrollService.Core.PayrollDatabaseRepositories
{
    public interface IEmployeeRepository : IRepository<Employee>
    {
    }

    public class EmployeeRepository : IEmployeeRepository
    {
        private DataAccess.Contexts.PayrollDatabaseContext context;
        public EmployeeRepository(DataAccess.Contexts.PayrollDatabaseContext _context)
        {
            context = _context;
        }

        public bool Delete(int id)
        {
            try

            {

                Employee _obj = context.Employee.FirstOrDefault(us => us.EmployeeId == id);

                if (_obj != null)

                {

                    context.Employee.Remove(_obj);

                }

                else

                {

                    return false;

                }

                return true;

            }

            catch

            {

                return false;

            }
        }

        public Employee Get(Expression<Func<Employee, bool>> expression)
        {
            return context.Employee.FirstOrDefault(expression);
        }

        public IEnumerable<Employee> GetAll()
        {
            return context.Employee.Select(a => a);
        }

        public Employee GetById(int id)
        {
            return context.Employee.FirstOrDefault(a => a.EmployeeId == id);
        }

        public IQueryable<Employee> GetMany(Expression<Func<Employee, bool>> expression)
        {
            return context.Employee.Where(expression);
        }

        public bool Insert(Employee obj)
        {
            try

            {


                context.Employee.Add(obj);

                return true;

            }

            catch (Exception)

            {

                return false;

            }
        }

        public bool Save()
        {
            try

            {

                context.SaveChanges();

                return true;

            }

            catch (Exception)

            {

                return false;

            }
        }

        public bool Update(Employee obj)
        {
            try

            {

                context.Employee.Update(obj);

                return true;

            }

            catch (Exception e)

            {
                Console.Write(e.ToString());
                return false;

            }
        }
    }
}
