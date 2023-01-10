using capgemini.EMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace capgemini.EMS.DAL
{
    public class EmployeeDAL
    {
        static List<Employee> list = new List<Employee>();
        public static bool Add(Employee emp)
        {
            list.Add(emp);
            return true;
        }
        public static List<Employee> GetList()
        {
            return list;
        }
        public static Employee GetById(int id)
        {
            //LINQ querry
            var emp = list.Where(e => e.Id == id).FirstOrDefault();

            return emp;
            }
        public static bool Update(Employee emp)
        {
            //get  emp by id
            var existingEmp = list.Where(e => e.Id == emp.Id).FirstOrDefault();

            existingEmp.Name = emp.Name;
            existingEmp.DateOfJoining = emp.DateOfJoining;

                return true;
        }
        public static bool Delete(int id)
        {
            
            var deleteEmp = list.Where(e => e.Id == id).FirstOrDefault();
            list.Remove(deleteEmp);
           //// deleteEmp.Name = emp.Name;
          //  deleteEmp.DateOfJoining = emp.DateOfJoining;
            
            return true;
        }
        }
    }

