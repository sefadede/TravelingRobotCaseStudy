using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelingRobotCaseStudy
{
    enum Direction
    {
        N,
        E,
        S,
        W
    }

    class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Dir { get; set; }

        public Robot(int x, int y, Direction dir)
        {
            X = x;
            Y = y;
            Dir = dir;
        }

        public void TurnLeft()
        {
            Dir = (Direction)(((int)Dir + 3) % 4);
        }

        public void TurnRight()
        {
            Dir = (Direction)(((int)Dir + 1) % 4);
        }

        public void MoveForward(int surfaceWidth, int surfaceHeight)
        {
            switch (Dir)
            {
                case Direction.N:
                    if (Y < surfaceHeight)
                        Y++;
                    break;
                case Direction.E:
                    if (X < surfaceWidth)
                        X++;
                    break;
                case Direction.S:
                    if (Y > 0)
                        Y--;
                    break;
                case Direction.W:
                    if (X > 0)
                        X--;
                    break;
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Mars yüzeyinin sağ üst köşesinin koordinatlarını giriniz :");
            string[] surfaceCoords = Console.ReadLine().Split(' ');
            int surfaceWidth = int.Parse(surfaceCoords[0]);
            int surfaceHeight = int.Parse(surfaceCoords[1]);

            Console.WriteLine("İlk robotik gezginin başlangıç pozisyonunu ve yönünü giriniz :");
            string[] startPos1 = Console.ReadLine().Split(' ');
            int x1 = int.Parse(startPos1[0]);
            int y1 = int.Parse(startPos1[1]);
            Direction dir1 = (Direction)Enum.Parse(typeof(Direction), startPos1[2]);

            Console.WriteLine("İkinci robotik gezginin başlangıç pozisyonunu ve yönünü giriniz :");
            string[] startPos2 = Console.ReadLine().Split(' ');
            int x2 = int.Parse(startPos2[0]);
            int y2 = int.Parse(startPos2[1]);
            Direction dir2 = (Direction)Enum.Parse(typeof(Direction), startPos2[2]);

            Console.WriteLine("İlk robotik gezginin hareket komutlarını giriniz:");
            string commands1 = Console.ReadLine();

            Console.WriteLine("İkinci robotik gezginin hareket komutlarını giriniz:");
            string commands2 = Console.ReadLine();

            Robot robot1 = new Robot(x1, y1, dir1);
            Robot robot2 = new Robot(x2, y2, dir2);

            ExecuteCommands(robot1, commands1, surfaceWidth, surfaceHeight);
            ExecuteCommands(robot2, commands2, surfaceWidth, surfaceHeight);

            Console.WriteLine($"İlk robotun son konumu: {robot1.X} {robot1.Y} {robot1.Dir}");
            Console.WriteLine($"İkinci robotun son konumu: {robot2.X} {robot2.Y} {robot2.Dir}");

            Console.ReadLine();
        }
        static void ExecuteCommands(Robot robot, string commands, int surfaceWidth, int surfaceHeight)
        {
            foreach (char command in commands)
            {
                switch (command)
                {
                    case 'L':
                        robot.TurnLeft();
                        break;
                    case 'R':
                        robot.TurnRight();
                        break;
                    case 'M':
                        robot.MoveForward(surfaceWidth, surfaceHeight);
                        break;
                    default:
                        Console.WriteLine($"Geçersiz komut: {command}");
                        break;
                }
            }
        }
    }
}
