using System.IO.Pipes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
namespace lab10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //    List<Customer> MyCustomerList = new List<Customer>
            //{
            //    new Customer {CustomerID = "ALFKI", ContactName = "Maria", City = "HCM"},
            //    new Customer {CustomerID = "ANATR", ContactName = "Ana", City = "HN"},
            //    new Customer {CustomerID = "ANTON", ContactName = "Antonio", City = "HN"}
            //};
            //    var query = from c in MyCustomerList
            //                where c.City == "HN"
            //                select new { c.CustomerID, c.ContactName };
            //    foreach (var c in query)
            //        Console.WriteLine($"{c.ContactName}");
            //    List<int> list = new List<int> { 1, -2, 3, -4, 5, -98, 35 };
            //    var sortedNumbers = list.OrderBy(n => n);
            //    foreach (var number in sortedNumbers)
            //    {
            //        Console.WriteLine(number);
            //    }
            //}

            //    public static List<Person> GenerateListOfPeople()
            //{
            //    var people = new List<Person>();
            //    people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1, });
            //    people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 });
            //    people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 });
            //    people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 });
            //    people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 });
            //    return people;
            //}
            //public static List<Company> GenerateCompanies()
            //{
            //    return new List<Company>
            //        {
            //            new Company { Id = 1, Name = "Microsoft" },
            //            new Company { Id = 2, Name = "Google" },
            //            new Company { Id = 3, Name = "Apple" }
            //        };
            //}
            //List<Person> people = GenerateListOfPeople();
            //    var companies = GenerateCompanies();
            //    var peopleWithCompanies = people.Join(person => person.CompanyId);
            //}
            List<int> numbers = new List<int>
            {
                12, -5, 0, 7, -14, 25, -1, 3, 8, -9,
                17, -22, 4, -3, 10, -6, 31, -17, 2, -8,
                19, -12, 0, 23, -30, 11, -7, 5, -15, 9,
                26, -18, 6, -4, 13, -2, 16, -20, 1, -10,
                28, -11, 14, -13, 15, -19, 18, -16, 21, -21
            };
            var test = numbers
                .Where(n => n > 0)
                .OrderBy(n => n)
                .Select(n => n)
                .ToList();
            foreach (var number in test)
            {
                Console.WriteLine(number);
            }

            var test2 = numbers.Where(n => n ).OrderBy(n => n % 2 =0).ToList();
            public static List<Company> GenerateCompanies()
        {
            return new List<Company> {
                new Company { Id = 1, Name = "Microsoft" },
                new Company { Id = 2, Name = "Google" },
                new Company { Id = 3, Name = "Apple" }
                };
        }

        var peopletest = new List<Person>
        {
            new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24, CompanyId = 1 },
            new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40, CompanyId = 1 },
            new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30, CompanyId = 2 },
            new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35, CompanyId = 1 },
            new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24, CompanyId = 2 },
            new Person { FirstName = "Tom", LastName = "Henderson", Occupation = "QA", Age = 28, CompanyId = 1 },
            new Person { FirstName = "Anna", LastName = "Nguyen", Occupation = "HR", Age = 31, CompanyId = 3 },
            new Person { FirstName = "Mark", LastName = "Tran", Occupation = "Dev", Age = 26, CompanyId = 1 },
            new Person { FirstName = "Emily", LastName = "Clark", Occupation = "Manager", Age = 38, CompanyId = 2 },
            new Person { FirstName = "John", LastName = "Phan", Occupation = "QA", Age = 29, CompanyId = 3 },
            new Person { FirstName = "Chris", LastName = "Lee", Occupation = "Support", Age = 32, CompanyId = 2 },
            new Person { FirstName = "Tina", LastName = "Vo", Occupation = "HR", Age = 36, CompanyId = 1 },
            new Person { FirstName = "Alex", LastName = "Khan", Occupation = "Dev", Age = 23, CompanyId = 3 },
            new Person { FirstName = "Natalie", LastName = "Wang", Occupation = "Manager", Age = 41, CompanyId = 2 },
            new Person { FirstName = "Brian", LastName = "Hoang", Occupation = "Dev", Age = 27, CompanyId = 1 },
            new Person { FirstName = "Lucy", LastName = "Kim", Occupation = "Dev", Age = 29, CompanyId = 3 },
            new Person { FirstName = "Victor", LastName = "Ng", Occupation = "DevOps", Age = 33, CompanyId = 2 },
            new Person { FirstName = "Rachel", LastName = "Ly", Occupation = "QA", Age = 30, CompanyId = 1 },
            new Person { FirstName = "Tommy", LastName = "Pham", Occupation = "Support", Age = 27, CompanyId = 3 },
            new Person { FirstName = "Jasmine", LastName = "Le", Occupation = "Dev", Age = 24, CompanyId = 1 },
            new Person { FirstName = "Daniel", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 2 },
            new Person { FirstName = "Linda", LastName = "Ngoc", Occupation = "HR", Age = 39, CompanyId = 3 },
            new Person { FirstName = "Peter", LastName = "Lam", Occupation = "QA", Age = 35, CompanyId = 1 },
            new Person { FirstName = "Sophia", LastName = "Dao", Occupation = "Manager", Age = 42, CompanyId = 2 },
            new Person { FirstName = "Albert", LastName = "Vo", Occupation = "Dev", Age = 25, CompanyId = 3 },
            new Person { FirstName = "Mia", LastName = "Pham", Occupation = "Dev", Age = 23, CompanyId = 2 },
            new Person { FirstName = "Nathan", LastName = "Do", Occupation = "Support", Age = 34, CompanyId = 1 },
            new Person { FirstName = "Karen", LastName = "Tran", Occupation = "QA", Age = 28, CompanyId = 3 },
            new Person { FirstName = "Henry", LastName = "Bui", Occupation = "DevOps", Age = 31, CompanyId = 2 },
            new Person { FirstName = "Lily", LastName = "Mai", Occupation = "Manager", Age = 43, CompanyId = 1 },
            new Person { FirstName = "Dylan", LastName = "Nguyen", Occupation = "Dev", Age = 30, CompanyId = 3 },
            new Person { FirstName = "Isabella", LastName = "Pham", Occupation = "Dev", Age = 26, CompanyId = 2 },
            new Person { FirstName = "Jason", LastName = "Le", Occupation = "Support", Age = 29, CompanyId = 1 },
            new Person { FirstName = "Cindy", LastName = "Vo", Occupation = "QA", Age = 27, CompanyId = 3 },
            new Person { FirstName = "Kevin", LastName = "Tran", Occupation = "Dev", Age = 28, CompanyId = 2 },
            new Person { FirstName = "Amy", LastName = "Lam", Occupation = "Manager", Age = 37, CompanyId = 1 },
            new Person { FirstName = "Sean", LastName = "Hoang", Occupation = "DevOps", Age = 32, CompanyId = 3 },
            new Person { FirstName = "Nina", LastName = "Huynh", Occupation = "HR", Age = 33, CompanyId = 2 },
            new Person { FirstName = "Tony", LastName = "Ngoc", Occupation = "Dev", Age = 25, CompanyId = 1 },
            new Person { FirstName = "Grace", LastName = "Nguyen", Occupation = "Dev", Age = 26, CompanyId = 3 },
            new Person { FirstName = "David", LastName = "Ly", Occupation = "Support", Age = 30, CompanyId = 2 },
            new Person { FirstName = "Olivia", LastName = "Pham", Occupation = "Dev", Age = 24, CompanyId = 1 },
            new Person { FirstName = "Ethan", LastName = "Le", Occupation = "QA", Age = 28, CompanyId = 3 },
            new Person { FirstName = "Ashley", LastName = "Truong", Occupation = "Dev", Age = 22, CompanyId = 2 },
            new Person { FirstName = "Tyler", LastName = "Kim", Occupation = "Manager", Age = 39, CompanyId = 1 },
            new Person { FirstName = "Luna", LastName = "Vo", Occupation = "DevOps", Age = 34, CompanyId = 3 },
            new Person { FirstName = "Zack", LastName = "Nguyen", Occupation = "Dev", Age = 27, CompanyId = 2 },
            new Person { FirstName = "Bella", LastName = "Pham", Occupation = "Support", Age = 31, CompanyId = 1 }
        };
        var 
    }

        public class Customer
        {
            public string CustomerID { get; set; }
            public string ContactName { get; set; }
            public string City { get; set; }
        }
        public class Person
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Occupation { get; set; }


            public int Age { get; set; }
            public int CompanyId { get; set; }
        }
        public class Company
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}


    

