using System;
using System.Collections.Generic;

namespace Interface_Segregation_principle_ISP
{
    class Program
    {
        static void Main(string[] args)
        {
            IReadonlyRepository readonlyRepository = new BadEmployeeRepository();

            IRepository repository = new BadEmployeeRepository();



            //Bessere Variante


            ICanAdd insertRepository = new BetterRepository();
            insertRepository.Insert();

        }
    }


    public class Employee
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Birthday { get; set; }
    }

    #region BadCode
    //Eine Repository Klasse repärsentiert eine Tabelle. 
    //Die Repository Klasse kann ein komplettes CRUD auf eine Tabelle anwenden
    //CRUD -> Create / Read / Update / Delete
    public interface IReadonlyRepository
    {
        Employee GetById(int id);
        IList<Employee> GetAll();
     }

    public interface IRepository : IReadonlyRepository
    {
        void Update(int id, Employee em);
        void Insert(Employee em);
        void Delete(int id);
    }

    public class BadEmployeeRepository : IRepository
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public Employee GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee em)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Employee em)
        {
            throw new NotImplementedException();
        }
    }
    #endregion



    #region Better


    public interface ICanRead
    {
        IList<Employee> ReadAll();
        Employee GetById();
    }

    public interface ICanAdd
    {
        void Insert(Employee employee);
    }

    public interface ICanUpdate
    {
        void Update(int id, Employee employee);
    }

    public interface ICanDelete
    {
        void Delete(int id);
    }


    public class BetterRepository : ICanAdd, ICanRead, ICanUpdate, ICanDelete
    {
        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Employee GetById()
        {
            throw new NotImplementedException();
        }

        public void Insert(Employee employee)
        {
            throw new NotImplementedException();
        }

        public IList<Employee> ReadAll()
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }


    #endregion
}
