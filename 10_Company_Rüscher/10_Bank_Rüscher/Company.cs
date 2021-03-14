using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10_Bank_Rüscher
{
    public class Company
    {
        //fields
        Dictionary<int, Employee> empDictionary = new Dictionary<int, Employee>();

        //properties
        public Dictionary<int, Employee>.ValueCollection Employees
        {
            get
            {
                return empDictionary.Values;
            }
        }

        //methods
        public bool AddEmployee(int id, string name)
        {
            Employee employee = new Employee(id, name);

            if(empDictionary.ContainsKey(id) == true)
            {
                return true;
            }
            else
            {
                empDictionary.Add(id, employee);
                return false;
            }
        }

        public void Delete(Employee emp)
        {
            empDictionary.Remove(emp.Id);
        }

        public List<Employee> Find(string name)
        {
            List<Employee> find = new List<Employee>();
            foreach(Employee e in empDictionary.Values)
            {
                if(name == e.Name)
                {
                    find.Add(e);
                }
            }

            return find;
        }
    }
}
