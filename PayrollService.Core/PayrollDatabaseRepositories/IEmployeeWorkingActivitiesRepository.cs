using PayrollService.Model.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace PayrollService.Core.PayrollDatabaseRepositories
{
    public interface IEmployeeWorkingActivitiesRepository : IRepository<EmployeeWorkingActivities>
    {
    }

    public class EmployeeWorkingActivitiesRepository : IEmployeeWorkingActivitiesRepository
    {
        private DataAccess.Contexts.PayrollDatabaseContext context;
        public EmployeeWorkingActivitiesRepository(DataAccess.Contexts.PayrollDatabaseContext _context)
        {
            context = _context;
        }
        public bool Delete(int id)
        {
            try

            {

                EmployeeWorkingActivities _obj = context.EmployeeWorkingActivities.FirstOrDefault(us => us.EmployeeWorkingActivitiesId == id);

                if (_obj != null)

                {

                    context.EmployeeWorkingActivities.Remove(_obj);

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

        public EmployeeWorkingActivities Get(Expression<Func<EmployeeWorkingActivities, bool>> expression)
        {
            return context.EmployeeWorkingActivities.FirstOrDefault(expression);
        }

        public IEnumerable<EmployeeWorkingActivities> GetAll()
        {
            return context.EmployeeWorkingActivities.Select(a => a);
        }

        public EmployeeWorkingActivities GetById(int id)
        {
            return context.EmployeeWorkingActivities.FirstOrDefault(a => a.EmployeeWorkingActivitiesId == id);
        }

        public IQueryable<EmployeeWorkingActivities> GetMany(Expression<Func<EmployeeWorkingActivities, bool>> expression)
        {
            return context.EmployeeWorkingActivities.Where(expression);
        }

        public bool Insert(EmployeeWorkingActivities obj)
        {
            try

            {


                context.EmployeeWorkingActivities.Add(obj);

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

        public bool Update(EmployeeWorkingActivities obj)
        {
            try

            {

                context.EmployeeWorkingActivities.Update(obj);

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
