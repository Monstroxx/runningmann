using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace runningmann
{
    public class Design
    {
        // mann
        int lastX = -1;
        int lastY = -1;
        int leg = 0;
        public void DrawMann(int x, int y)
        {
            string[] legs =
            {
                "/\\",
                "/ |",
                "/|",
                "\\\\",
                "| \\",
                "/ \\"
            };

            // Clear the previous position of the character by overwriting it with spaces.
            if (lastX >= 0 && lastY >=0)
            {
                Console.SetCursorPosition(lastX, lastY);
                Console.Write("  ");
                Console.SetCursorPosition(lastX, lastY + 1);
                Console.Write("   ");
                Console.SetCursorPosition(lastX, lastY + 2);
                Console.Write("   ");
            }
            // Draw the character at the new position.
            Console.SetCursorPosition(x, y);
            Console.Write(" O");
            Console.SetCursorPosition(x, y + 1);
            Console.Write("/|\\");
            Console.SetCursorPosition(x, y + 2);
            Console.Write(legs[leg]);

            leg = (leg + 1) % legs.Length; // Cycle through leg positions to create a running animation effect.
            
            lastX = x;
            lastY = y;
        }

        public static string obstacledesign = "#";

        static void consoledesign()
        {
            string[] topleft = { "╔", "║", "╟" };
            string[] topright = { "╗", "║", "╢" };
            string vertical = "║";
            string horizontal = "═";
            string bottomleft = "╚";
            string bottomright = "╝";
        }
        public void DrawConsole()
        {
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            // Draw top border
            Console.Write("╔");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.WriteLine("╗");
            // Draw sides
            for (int i = 0; i < height - 2; i++)
            {
                Console.Write("║");
                for (int j = 0; j < width - 2; j++)
                    Console.Write(" ");
                Console.WriteLine("║");
            }
            // Draw bottom border
            Console.Write("╚");
            for (int i = 0; i < width - 2; i++)
                Console.Write("═");
            Console.WriteLine("╝");
        }
    }
}
