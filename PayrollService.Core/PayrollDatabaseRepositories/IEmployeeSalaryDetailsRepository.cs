using PayrollService.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PayrollService.Core.PayrollDatabaseRepositories
{
    public interface IEmployeeSalaryDetailsRepository:IRepository<EmployeeSalaryDetails>
    {
    }
    public class EmployeeSalaryDetailsRepository : IEmployeeSalaryDetailsRepository
    {
        private DataAccess.Contexts.PayrollDatabaseContext context;
        public EmployeeSalaryDetailsRepository(DataAccess.Contexts.PayrollDatabaseContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            try

            {

                EmployeeSalaryDetails _obj = context.EmployeeSalaryDetails.FirstOrDefault(us => us.EmployeeSalaryDetailsId == id);

                if (_obj != null)

                {

                    context.EmployeeSalaryDetails.Remove(_obj);

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

        public EmployeeSalaryDetails Get(Expression<Func<EmployeeSalaryDetails, bool>> expression)
        {
            return context.EmployeeSalaryDetails.FirstOrDefault(expression);
        }

        public IEnumerable<EmployeeSalaryDetails> GetAll()
        {
            return context.EmployeeSalaryDetails.Select(a => a);
        }

        public EmployeeSalaryDetails GetById(int id)
        {
            return context.EmployeeSalaryDetails.FirstOrDefault(a => a.EmployeeSalaryDetailsId == id);
        }

        public IQueryable<EmployeeSalaryDetails> GetMany(Expression<Func<EmployeeSalaryDetails, bool>> expression)
        {
            return context.EmployeeSalaryDetails.Where(expression);
        }

        public bool Insert(EmployeeSalaryDetails obj)
        {
            try

            {


                context.EmployeeSalaryDetails.Add(obj);

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

        public bool Update(EmployeeSalaryDetails obj)
        {
            try

            {

                context.EmployeeSalaryDetails.Update(obj);

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
