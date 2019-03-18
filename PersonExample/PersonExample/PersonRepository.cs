using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PersonExample.Models;

namespace PersonExample
{
    class PersonRepository
    {
        private readonly PersontestdbContext _persontestdbContext = new PersontestdbContext();

        public void Create(Person person)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReadByCity(string city)
        {
            //var persons = _persontestdbContext.Person.
            //    FromSql($"SELECT * FROM PERSON WHERE CITY = {city}").
            //    ToList();

            var persons = _persontestdbContext.
                Person.
                Where(p => p.City == city).
                ToListAsync().
                Result;
            return persons;
        }

        public Person ReadById(long id)
        {

            // Vaihtoehto A
            //var person = _persontestdbContext.
            //    Person.
            //    FromSql($"SELECT * FROM PERSON WHERE ID = {id}").
            //    FirstOrDefault();

            // Vaihtoehto B
            //var person = _persontestdbContext.
            //    Person.
            //    FirstOrDefault(p => p.Id == id);

            // Vaihtoehto C
            var person = _persontestdbContext.Person.Find(id);


            return person;
        }

        public void Update(long id, Person person)
        {
            throw new NotImplementedException();
        }

        public void Delete(long id)
        {
            throw new NotImplementedException();
        }
    }
}

