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
            newPerson.Name = "Ville-Petteri Galle";
            newPerson.Age = 31;
            newPerson.Phone = new List<Phone>
            {
                new Phone{Type="koti", Number = "020202"},
                new Phone{Type="työ", Number = "0100100"}
            };

            string msg = "";

            ConsoleKeyInfo cki;
            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        Console.Clear();
                        personRepository.Create(newPerson);
                        msg = "Tiedot lisätty onnistuneesti!" +
                            "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        personRepository.Read();
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        personRepository.Update(UserInputId(), newPerson);
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        personRepository.Delete(UserInputId());
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.X:
                        Console.Clear();
                        msg = "Kiitos käynnistä, tervetuloa uudelleen!";
                        break;

                    default:
                        Console.Clear();
                        msg = "Painoit väärää nappulaa! Paina nappulaa aloittaaksesi alusta.";
                        break;
                }
                Console.WriteLine(msg);
                Console.ReadKey();

            } while (cki.Key != ConsoleKey.X);
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("TIETOKANTAOHJELMOINTITEHTÄVÄ 1:\n\n" +
                "[C] Lisää tietokantaan uusi tietue.\n" +
                "[R] Lue tietokannasta tietoja.\n" +
                "[U] Päivitä henkilön tiedot.\n" +
                "[D] Poista henkilö tietokannasta.\n" +
                "[X] Poistu ohjelmasta.\n");


            return Console.ReadKey();
        }

        private static long UserInputId()
        {
            Console.WriteLine("Syötä ID:");
            while (true)
            {
                if (long.TryParse(Console.ReadLine(), out long id))
                {
                    return id;
                }

                else
                    Console.WriteLine("Väärä syöte! Kirjoita numeroita.");
            }
        }
    }
}
