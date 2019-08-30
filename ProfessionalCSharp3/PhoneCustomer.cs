using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProfessionalCSharp3
{
    public class PhoneCustomer
    {
        private string _firstName;
        //常量
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;

        //表达式属性访问器
        public string FirstName
        {
            get => _firstName;
            set => _firstName = value;
        }
        public string LastName;

        public int Age { get; set; } = 42;
    }

    struct PhoneCustomerStruct
    {
        public const string DayOfSendingBill = "Monday";
        public int CustomerID;
        public string FirstName;
        public string LastName;
    }

    public class DoumentEditor
    {
        private static readonly uint s_maxDocuments;

        static DoumentEditor()
        {
            s_maxDocuments = 1;
        }
    }

    public class Document
    {
        private readonly DateTime _createTime;

        public Document()
        {
            _createTime=DateTime.Now;
        }
       
    }

    public class Person
    {
        public Person(string name) => Name = name;
        public string Id { get; } = Guid.NewGuid().ToString();
         public string Name { get; }
    }

    public class ResultDisplayer
    {
        public void DisplayResult(string result)
        {
            
        }

        public void DisplayResult(int result)
        {
            
        }
        public void DisplayResult(int result,int y)
        {

        }
    }

   
    public struct AS
    {
        public int X { get; set; }
    }

    public class AC
    {
        public  int X { get; set; }
    }



}
