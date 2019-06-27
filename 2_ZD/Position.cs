using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2_ZD
{
    class Position
    {
        int x, y;
        public int X
        {
            get
            {
                return x;
            }
            set
            {
                x = value;
            }
        }
        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
        public Position()
        {
            X = -1;
            Y = -1;
        }
        public Position(int _x, int _y)
        {
            X = _x;
            Y = _y;
        }
        public override bool Equals(object obj)
        {
            Position other = obj as Position;
            if (other != null)
            {
                return X == other.X && Y == other.Y;
            }
            throw new FormatException();
        }
    }
}