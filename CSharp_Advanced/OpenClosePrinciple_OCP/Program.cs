using System;

namespace OpenClosePrinciple_OCP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    #region BadCode
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class ReportGenerator
    {
        public string ReportTyp { get; set; }

        public void GenerateReport()
        {
            if (ReportTyp == "CR")
            {
                //Crystal Reports
            }
            else if (ReportTyp == "PDF")
            {
                //PDF
            }
        }
    }
    #endregion

    public interface IReportGenerator
    {
        void ReportGenerator(Employee em);
    }

    public abstract class ReportGeneratorBase
    {
        public abstract void ReportGenerator(Employee em);
    }

    public class CrystalReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            //Erstelle Crystal Report
        }
    }

    public class PDFReportGenerator : ReportGeneratorBase
    {
        public override void ReportGenerator(Employee em)
        {
            //Erstelle PDF
        }
    }
}
