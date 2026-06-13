using System;
using System.Numerics;
using DoDO.CharacterData;

namespace DoDO.GameClasses
{
    class Program
    {



        /* static void Main(string[] args)
          {
              Console.WriteLine("Hello World!");
              bool game = true;

              System.Diagnostics.Process.Start("cmd.exe");
              while (game)
              {
                  Console.WriteLine("WELCOME TO Death of Doom Orcs");
                  Console.WriteLine("Pick your class Adventurer!");
                  string userName = Console.ReadLine();
              }


          }*/

        static void Main()
        {
            Character player;
            //Character enemy = new Warrior("Goblin");
            RenderEngine renderer = new RenderEngine();
            renderer.Render_title();

            Game game = new Game();

            Commentator commentator = new Commentator();
            commentator.Subscribe(game);

            game.Start();

            Console.ReadKey();
        }
    }
}
