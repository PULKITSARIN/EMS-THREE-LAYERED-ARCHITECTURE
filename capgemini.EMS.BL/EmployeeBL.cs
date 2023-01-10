using capgemini.EMS.DAL;
using capgemini.EMS.Entities;
using capgemini.EMS.EXceptions;
using Nest;
using System;
using System.Collections.Generic;

namespace capgemini.EMS.BL
{
    public class EmployeeBL
    {
        public static bool Add(Employee emp)
        {
            if (emp.Id <= 0)
            {
                throw new EmsException("Employee id should be greater then 0");

            }
            bool isAdded = EmployeeDAL.Add(emp);
            return isAdded;
        }
        public static List<Employee> GetList()
        {
            var list = EmployeeDAL.GetList();
            return list;
        }

        public static Employee GetById(int id)
        {
        var emp = EmployeeDAL.GetById(id);
         return emp;
            }

        public static bool Update(Employee emp)
        {
            bool isUpdated = EmployeeDAL.Update(emp);
            return isUpdated;
        }
        public static bool Delete(int id)
        {
            var isDeleted = EmployeeDAL.Delete(id);
            return isDeleted;
        }
    }
}
