using System;
using System.Collections.Generic;
using System.Text;

namespace DoDO.GameClasses
{
    internal class RenderEngine
    {

        public void RenderGlobal()
        {
            Console.Clear();
            Render_title();
            Render_state();
            Render_Log();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }

        public void Render_title()
        {
            Console.WriteLine("\n=================================================================================================================");
            Console.WriteLine("\n===========================================D O D O , Death of The Doom Orcs =====================================");
            Console.WriteLine("\n=================================================================================================================");
        }

        public void Render_state()
        {
           Console.WriteLine($"\nPotions: {0} , Stats: , Life: Mana:");
        }

        public void Render_Log()
        {

        }

    }
}
