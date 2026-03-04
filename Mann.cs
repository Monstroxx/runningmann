using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;


namespace runningmann
{
    public class Mann
    {
        public int x;
        public int y;
        bool jumping = false;
        Design design = new Design();

        public Mann(int X, int Y)
        {
            x = X;
            y = Y;
        }

        public void Draw()
        {
            design.DrawMann(x, y);
            fall();
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
            else if (key.Key == ConsoleKey.Spacebar)
            {
                Jump();
            }
        }
        void Jump()
        {
            if (jumping) return; // Prevent double jumping.
            y += -6; 
            jumping = true;
        }
        void fall()
        {
            if (jumping)
            {
                if (y != Console.WindowHeight - 3)
                {
                    y += 1;
                }
                else
                {
                    jumping = false;
                }
            }
        }
    }
}
