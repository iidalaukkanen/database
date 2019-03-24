using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PersonPhoneDBExample.Models;

namespace PersonPhoneDBExample.Repositories
{
    class PersonRepository : IPersonRepository
    {
        private readonly PersondbContext _persondbContext = new PersondbContext();

        public void Create(Person person)
        {
            _persondbContext.Person.Add(person);
            _persondbContext.SaveChanges();
        }

        public List<Person> Read()
        {
            var persons = _persondbContext.Person
                .Include(p=>p.Phone)
                .ToList();
            return persons;
        }

        public Person Read(long id)
        {
            var person = _persondbContext.Person
                .FirstOrDefault(p => p.Id == id);

            return person;
        }

        public void Update(long id, Person person)
        {
            var isPersonAlive = Read(id);
            if (isPersonAlive != null)
            {
                _persondbContext.Update(person);
                _persondbContext.SaveChanges();
                Console.WriteLine("Tiedot tallennettu onnistuneesti!");

            }
            else
                Console.WriteLine("Tietojen tallennus epäonnistui - henkilöä ei ole olemassa.");
        }

        public void Delete(long id)
        {
            var deletedPerson = Read(id);
            if (deletedPerson != null)
            {
                _persondbContext.Person.Remove(deletedPerson);
                _persondbContext.SaveChanges();
                Console.WriteLine("Tiedot poistettu onnistuneesti!");
            }
            else
                Console.WriteLine("Tiedon poisto EI onnistunut - ID tuntematon");
        }
    }
}
