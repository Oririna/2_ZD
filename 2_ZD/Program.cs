using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _2_ZD
{
    class Program
    {
        static int[] dx = new int[] { -2, -1, 1, 2, 2, 1, -1, -2 };
        static int[] dy = new int[] { 1, 2, 2, 1, -1, -2, -2, -1 };
        const int size = 8;
        const int directions = 8;
        static bool IsPossible(Position pos)
        {
            return pos.X >= 0 && pos.X < size && pos.Y >= 0 && pos.Y < size;
        }
        static void Main(string[] args) //загрузка и выгрузка файла
        {
            StreamReader sr = new StreamReader("input.txt");
            StreamWriter sw = new StreamWriter("output.txt");
            string[] positions = sr.ReadToEnd().Split(',');
            positions[1] = positions[1].TrimStart(' ');
            sr.Close();
            Position from = new Position(positions[0][0] - 'a', positions[0][1] - '1');
            Position to = new Position(positions[1][0] - 'a', positions[1][1] - '1');
            for (int i = 0; i < directions; i++)
            {
                Position nextPosition = new Position(from.X + dx[i], from.Y + dy[i]);
                if (IsPossible(nextPosition) == false)
                {
                    continue;
                }
                if (nextPosition.Equals(to))
                {
                    sw.Write('1');
                    sw.Close();
                    return;
                }
            }
            for (int i = 0; i < directions; i++) // просмотр позиций 
            {
                Position firstStep = new Position(from.X + dx[i], from.Y + dy[i]);
                if (IsPossible(firstStep) == false)
                {
                    continue;
                }
                for (int j = 0; j < directions; j++)
                {
                    Position secondStep = new Position(firstStep.X + dx[j], firstStep.Y + dy[j]);
                    if (IsPossible(secondStep) == false)
                    {
                        continue;
                    }
                    if (secondStep.Equals(to))
                    {
                        sw.Write('2');
                        sw.Close();
                        return;
                    }
                }
            }
            sw.Write("NO");
            sw.Close();
        }
    }
}