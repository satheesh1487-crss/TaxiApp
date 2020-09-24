using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SampleEmp.EmpModels;
namespace SampleEmp 
{
    public class Employeectrl
    {
        public bool InsertEmployee(TaxiAppzDBContext context,Employee employee)
        {
            try
            {
                 TabEmployeeDetails tabEmployeeDetails = new TabEmployeeDetails();
                tabEmployeeDetails.EmpFirstname = employee.Firstname;
                tabEmployeeDetails.EmpLastname = employee.Lastname;
                tabEmployeeDetails.EmpEmailid = employee.Email;
                tabEmployeeDetails.EmpAge = employee.Age;
                tabEmployeeDetails.EmpContactno = employee.Phoneno;
                tabEmployeeDetails.EmpDob = Convert.ToDateTime(employee.Dob);
                tabEmployeeDetails.Gender = employee.Gender;
                context.Add(tabEmployeeDetails);
                context.SaveChanges();
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
    }
}
