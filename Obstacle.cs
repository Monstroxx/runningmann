using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runningmann
{
    public class Obstacle
    {
        public int x { get; set; }
        public int y { get; set; }

        static string design = Design.obstacledesign;

        int x_vec;

        public Obstacle(int X, int Y, int X_vec)
        {
            x = X;
            y = Y;
            x_vec = X_vec;
        }
        public void Move(List<Obstacle> Obstacles)
        {
            for (int i = 0; i < Obstacles.Count; i++)
            {
                Obstacles[i].x += Obstacles[i].x_vec;
                if (Obstacles[i].x < 1)
                {
                    Obstacles.RemoveAt(i);
                    i--;
                }
                else
                {
                    //clear old position
                    int oldX = Obstacles[i].x - Obstacles[i].x_vec;
                    int oldY = Obstacles[i].y;
                    Console.SetCursorPosition(oldX, oldY);
                    Console.Write(" ");
                    Console.SetCursorPosition(oldX, oldY - 1);
                    Console.Write(" ");
                    // draw new position
                    int X = Obstacles[i].x;
                    int Y = Obstacles[i].y;
                    Console.SetCursorPosition(X, Y);
                    Console.Write(design);
                    Console.SetCursorPosition(X, Y - 1);
                    Console.Write(design);
                }
            }
        }

        static class Global
        {
            public static int speed = 100; // Speed of the obstacles, lower is faster. 
            public static int obstaclerate = 10; // Chance of an obstacle spawning each frame, out of 100.
        }
        public bool spawn()
        {
            Random rand = new();
            if (rand.Next(0, 100) < Global.obstaclerate)
            {
                return(true);
            }
            return(false);
        }
    }  
}
