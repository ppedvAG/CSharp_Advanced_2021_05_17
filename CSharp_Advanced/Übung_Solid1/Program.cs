using System;

namespace Übung_Solid1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }


    public class BadEmployee
    {
        public int Employee_Id { get; set; }
        public string Employee_Name { get; set; }

        public string ReportType { get; set; }

        /// <summary>
        /// This method used to insert into employee table
        /// </summary>
        /// <param name="em">Employee object</param>
        /// <returns>Successfully inserted or not</returns>
        public bool InsertIntoEmployeeTable(BadEmployee em)
        {
            // Insert into employee table.
            return true;
        }
        /// <summary>
        /// Method to generate report
        /// </summary>
        /// <param name="em"></param>


        public void GenerateReport(BadEmployee em)
        {
            if (ReportType == "CRS")
            {
                // Report generation with employee data in Crystal Report.
            }
            if (ReportType == "PDF")
            {
                // Report generation with employee data in PDF.
            }
        }
    }

    public interface IEntity
    {
        public int Id { get; set; }
        public DateTime CreateAt { get; set; }
        public DateTime ModifiedAt { get; set; }
    }

    public interface IEmployee
    {
        int Id { get; set; }
        string Name { get; set; }
    }

    public class Employee : IEmployee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    public interface ICanInsert<T> where T : class
    {
        public bool InsertIntoTable(T em);
    }

    public class EmployeeRepository
    {
        public bool InsertIntoTable(IEmployee em)
        {
            //Mach was

            return true;
        }
    }

    public abstract class Reports
    {
        public abstract void GenerateReport(IEmployee employee);
    }


    public class CrystalReports : Reports //IReports (Alternative) 
    {
        public override void GenerateReport(IEmployee employee)
        {
            throw new NotImplementedException();
        }
    }

    public class PDFReports : Reports //IReports (Alternative) 
    {
        public override void GenerateReport(IEmployee employee)
        {
            throw new NotImplementedException();
        }
    }


}
