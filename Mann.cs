using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runningmann
{
    public class Mann(int X, int Y)
    {
        public int x = X;
        public int y = Y;
        int leg = 0;
        public void Draw()
        {
            Console.Clear();
            Console.SetCursorPosition(x, y);
            Console.Write(" O");
            Console.SetCursorPosition(x, y +1);
            Console.Write("/|\\");
            Console.SetCursorPosition(x, y +2);
            string[] legs =
            {
                "/\\",   
                "/ |",   
                "/|",   
                "\\\\",  
                "| \\",  
                "/ \\"    
            };

            Console.Write(legs[leg]);
            leg = (leg + 1) % legs.Length; // Cycle through leg positions to create a running animation effect.
        }

        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.LeftArrow)
            {
                x = Math.Max(0, x - 1); // Prevent moving out of bounds. Math.Max to ensure x doesn't go below 0.
            }
            else if (key.Key == ConsoleKey.RightArrow)
            {
                x = Math.Min(Console.WindowWidth - 3, x + 1); // Console.WindowWidth to ensure x doesn't exceed window width. "-3" because the character is 2 characters wide. 
            }
        }
    }
}
