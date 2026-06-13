using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DoDO.GameClasses.Game;

namespace DoDO.GameClasses
{
    public static class InputHandler
    {
        public static PlayerAction GetPlayerAction()
        {
            Console.WriteLine();
            Console.WriteLine("Wybierz akcję:");
            Console.WriteLine("1 - Atak");
            Console.WriteLine("2 - Atak specjalny");
            Console.WriteLine("3 - Użyj Potiona");
            Console.WriteLine("9 - Zakończ grę");

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value) &&
                    Enum.IsDefined(typeof(PlayerAction), value))
                {
                    return (PlayerAction)value;
                }

                Console.WriteLine("Niepoprawny wybór!");
            }
        }

        public static ClassPick PickPlayerClass()
        {
            Console.WriteLine();
            Console.WriteLine("Wybierz Klasę:");
            Console.WriteLine("1 - Wojownik [Wysoka obrona, dużo życia]");
            Console.WriteLine("2 - Mag [Dużo obrażeń, dużo many]");
            Console.WriteLine("3 - Rouge [Średnie obrażenia, wysokie uniki]");
            

            while (true)
            {
                Console.Write("> ");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int value) &&
                    Enum.IsDefined(typeof(ClassPick), value))
                {
                    return (ClassPick)value;
                }

                Console.WriteLine("Niepoprawny wybór!");
            }
        }
    }
}
