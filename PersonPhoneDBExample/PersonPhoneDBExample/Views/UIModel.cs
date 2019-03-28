using PersonPhoneDBExample.Repositories;
using PersonPhoneDBExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonPhoneDBExample.Views
{
    class UIModel
    {
        private static readonly PersonRepository _personRepository = new PersonRepository();

        public void CreatePerson()
        {
            Person newPerson = new Person();
            newPerson.Name = "Pelastusmies Masa";
            newPerson.Age = 31;
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type="koti", Number = "112"},
                new Phone{Type="työ", Number = "911"}
            };

            _personRepository.Create(newPerson);
        }

        public void UpdatePerson()
        {
            long id;
            Console.WriteLine("Syötä ID henkilölle, jonka tiedot haluat päivittää:");
            while (!long.TryParse(Console.ReadLine(), out id))
            {
                Console.WriteLine("Väärä syöte! Kirjoitapa kuule numeroita.");
            }

            Person updatePerson = _personRepository.Read(id);
            updatePerson.Name = "virtahöpö";
            updatePerson.Age = 4;
            updatePerson.Phone = new List<Phone>
            {
                new Phone {Number = "1", Type = "trapphone"}
            };

            _personRepository.Update(id, updatePerson);
        }

        public void DeletePerson(long id)
        {
            _personRepository.Delete(id);
        }

        public void ReadById(long id)
        {
            var person = _personRepository.Read(id);

            if (person == null)
                Console.WriteLine($"Henkilöä numerolla {id} ei löydy!");

            else
            {
                Console.Write($"{person.Id} { person.Name} ");
                foreach (var phone in person.Phone)
                {
                    Console.Write($"{phone.Number} ");
                }
                Console.WriteLine();
            }
        }

        public void ReadList()
        {
            var persons = _personRepository.Read();

            foreach (var p in persons)
            {
                Console.Write($"{p.Id} { p.Name} ");
                foreach (var phone in p.Phone)
                {
                    Console.Write($"{phone.Number} ");
                }
                Console.WriteLine();
            }
        }
    }
}
