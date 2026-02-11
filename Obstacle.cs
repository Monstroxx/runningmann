using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace runningmann
{
    internal class Obstacle
    {
        public int x { get; set; }
        public int y { get; set; }
        public string design = "#";

        private int x_vec;

        public Obstacle(int X, int Y, int X_vec)
        {
            x = X;
            y = Y;
            x_vec = X_vec;
        }
    }
}
