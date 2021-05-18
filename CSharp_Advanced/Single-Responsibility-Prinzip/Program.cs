using System;

namespace Single_Responsibility_Prinzip
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region BadCode
    public class EmployeeBad
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public void InsertIntoEmployeeeTable(EmployeeBad employeeBad)
        {
            //Speichere Datensatz
        }

        public void GenerateReport(EmployeeBad employee)
        {
            //Erstelle Reports
        }
    }
    #endregion

    #region Better 

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ReportGenerator
    {
        public void GenerateReport(EmployeeBad employee)
        {
            //Erstelle Reports
        }
    }

    public class EmployeeeRepository //DataAccess Layer
    {
        public void InsertIntoEmployeeeTable(EmployeeBad employeeBad)
        {
            //Speichere Datensatz
        }
    }
    #endregion
}
