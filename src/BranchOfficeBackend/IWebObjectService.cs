using System.Collections.Generic;

namespace BranchOfficeBackend
{
    /// <summary>
    /// Translates DAL objects onto API Server (Web) objects.
    /// (Because e.g. Employee object in db may be different than
    /// the Employee object returned by API Server).
    /// The translation is kept here in order to obey Single Responsibility Rule.
    /// </summary>
    public interface IWebObjectService
    {
        /// <summary>
        /// Lists all employees.Throws exception on any problem
        /// </summary>
        /// <returns></returns>
        List<WebEmployee> GetAllEmployees();

        WebEmployee GetEmployee(int employeeId);

        /// <summary>
        /// Adds employee if the employee object is valid, throws exception otherwise.
        /// </summary>
        /// <param name="employee"></param>
        void AddEmployee(WebEmployee employee);

        /// <summary>
        /// Deletes employee if it exists, throws exception otherwise.
        /// </summary>
        /// <param name="employeeId"></param>
        void DeleteEmployee(int employeeId);

    }
}
