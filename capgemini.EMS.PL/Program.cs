using capgemini.EMS.BL;
using capgemini.EMS.Entities;
using capgemini.EMS.EXceptions;
using System;

namespace capgemini.EMS.PL
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("1 Add employee, 2 Employee List, 3 Update employee, 4 Delete Employee, 5 Exit");
                Console.WriteLine("Enter your choice");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out int choice))
                {
                    Console.WriteLine("invalid input");
                    return;
                }
                switch (choice)
                {
                    case 1:
                        AddEmployee();
                        break;
                    case 2:
                        EmployeeList();
                        break;
                    case 3:
                        UpdateEmployee();
                        break;
                    case 4:
                        DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("invalid");
                        break;
                }
            }
        }

        private static void DeleteEmployee()
        {
            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();

            } while (!int.TryParse(input, out empId));

            var existingemployee = EmployeeBL.GetById(empId);
            if (existingemployee == null)
            {
                Console.WriteLine("employee not found");
                return;

            }
            var isdeleted = EmployeeBL.Delete(empId);
            if (isdeleted)
            {
                Console.WriteLine("delete successfull");
            }
            else
            {
                Console.WriteLine("delete failed");
            }
        }

        private static void UpdateEmployee()
        {
            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();
                
            } while (!int.TryParse(input, out empId));

            var existingemployee = EmployeeBL.GetById(empId);
            if(existingemployee == null)
            {
                Console.WriteLine("employee not found");
                return;
           
            }
            do
            {
                Console.WriteLine("enter employee name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            existingemployee.Name = input;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter date of joining");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            existingemployee.DateOfJoining = dateOfJoining;

            var isUpdated = EmployeeBL.Update(existingemployee);
            if(isUpdated)
            {
                Console.WriteLine("update successfull");
            }
            else
            {
                Console.WriteLine("update failed");
            }

         
        }

        private static void EmployeeList()
        {
            var list = EmployeeBL.GetList();
            Console.WriteLine("Employee list");
            foreach (var emp in list)
            {
                Console.WriteLine(emp);
            }
        }

        private static void AddEmployee()
        {
            Employee newEmployee = new Employee();



            string input;
            int empId;
            do
            {
                Console.WriteLine("enter employee id");
                input = Console.ReadLine();
                // Console.WriteLine("invalid input");
                // return;
            } while (!int.TryParse(input, out empId));
            newEmployee.Id = empId;
            do
            {
                Console.WriteLine("enter employee name");
                input = Console.ReadLine();
            } while (string.IsNullOrEmpty(input));

            newEmployee.Name = input;
            DateTime dateOfJoining;
            do
            {
                Console.WriteLine("Enter date of joining");
                input = Console.ReadLine();
            } while (!DateTime.TryParse(input, out dateOfJoining));
            newEmployee.DateOfJoining = dateOfJoining;

            // call bl
            try
            {
                bool isAdded = EmployeeBL.Add(newEmployee);

                if (isAdded)
                {
                    Console.WriteLine("Employee add successfull");
                }
                else
                {
                    Console.WriteLine("Employee add fail");
                }
            }

            catch (EmsException ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
    



