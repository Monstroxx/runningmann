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
        int score;
        bool jumping = false;
        Designmann design = new Designmann();
        public int health;

        public Mann(int X, int Y)
        {
            x = X;
            y = Y;
            health = 3;
            score = 0;
        }

        public void Draw()
        {
            design.DrawMann(x, y);
            fall();
        }

        public void HandleInput()
        {
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.LeftArrow || key.Key == ConsoleKey.A)
            {
                x = Math.Max(0, x - 1); // Prevent moving out of bounds. Math.Max to ensure x doesn't go below 0.
            }
            else if (key.Key == ConsoleKey.RightArrow || key.Key == ConsoleKey.D)
            {
                x = Math.Min(Console.WindowWidth - 3, x + 1); // Console.WindowWidth to ensure x doesn't exceed window width. "-3" because the character is 2 characters wide. 
            }
            else if (key.Key == ConsoleKey.Spacebar || key.Key == ConsoleKey.UpArrow || key.Key == ConsoleKey.W)
            {
                Jump();
            }
        }
        void Jump()
        {
            if (jumping) return; // Prevent double jumping.
            y += -8; 
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
