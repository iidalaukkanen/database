using PersonPhoneDBExample.Models;
using PersonPhoneDBExample.Repositories;
using PersonPhoneDBExample.Views;
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
            UIModel uiModel = new UIModel();

            string msg = "";

            ConsoleKeyInfo cki;
            do
            {
                cki = UserInterface();
                switch (cki.Key)
                {
                    case ConsoleKey.C:
                        Console.Clear();
                        uiModel.CreatePerson();
                        msg = "Tiedot lisätty onnistuneesti!" +
                            "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.R:
                        Console.Clear();
                        uiModel.ReadList();
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.I:
                        Console.Clear();
                        uiModel.ReadById(UserInputId());
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.U:
                        Console.Clear();
                        uiModel.UpdatePerson();
                        msg = "\n____________________________________\nPaina nappulaa jatkaaksesi.";
                        break;

                    case ConsoleKey.D:
                        Console.Clear();
                        uiModel.DeletePerson(UserInputId());
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
                Console.Clear();

            } while (cki.Key != ConsoleKey.X);
        }

        private static ConsoleKeyInfo UserInterface()
        {
            Console.WriteLine("TIETOKANTAOHJELMOINTITEHTÄVÄ 1:\n\n" +
                "[C] Lisää tietokantaan uusi tietue.\n" +
                "[R] Lue tietokannan tiedot.\n" +
                "[I] Lue yhden henkiön tiedot tietokannasta.\n" +
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
