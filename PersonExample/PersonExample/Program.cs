using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonExample.Models;

namespace PersonExample
{
    class Program
    {
        private static readonly PersonRepository personRepository = new PersonRepository();
        static void Main(string[] args)
        {
            //testing database read
            CreatePerson();
            ReadByCity();
            for (int i = 0; i < 100; i++)
            {
                ReadById();
            }
        }

        static void CreatePerson()
        {
            Person person = new Person();
            person.FirstName = "James";
            person.LastName = "Bond";
            person.City = "London";
            person.ShoeSize = 42;

            _personRepository.Create(Person);
        }

        static void ReadByCity()
        {

        }

        static void ReadById()
        {

        }

    }
}
