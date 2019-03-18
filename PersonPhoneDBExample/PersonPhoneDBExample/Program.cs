using PersonPhoneDBExample.Models;
using PersonPhoneDBExample.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPhoneDBExample
{
    class Program
    {
        static void Main(string[] args)
        {
            PersonRepository personRepository = new PersonRepository();

            Person newPerson = new Person();
            newPerson.Name = "Pöllö Peloton";
            newPerson.Age = 3;
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type="koti", Number = "öööööööööö"},
                new Phone{Type="työ", Number = "0100100"}
            };

            personRepository.Create(newPerson);
            personRepository.Read();
        }
    }
}
