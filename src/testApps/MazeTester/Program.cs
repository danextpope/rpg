namespace MazeTester
{
    using System;
    using System.Linq;
    using AutoMapper;

    using FourZoas.RPG.Common;
    using FourZoas.RPG.Common.Automapper;
    using FourZoas.RPG.Maze;

    internal class Program
    {
        static Program() => Mapper.Initialize(cfg => cfg.AddProfile<DirectionMapperProfile>());

        private static void Main(string[] args)
        {
            var rnd = new Random();
            var maze = new GrowingTreeMaze<EmptyCell>(l => l.Count > 1 ? l.Count - 2 : 0);
            var map = new SquareGrid<Directions>(20, 20);

            var a = 0;
            while (a < 80)
            {
                var w = rnd.Next(1, 4) + rnd.Next(0, 3);
                var h = rnd.Next(1, 4) + rnd.Next(0, 3);
                int x, y;
                var done = true;
                x = rnd.Next(21 - w);
                y = rnd.Next(21 - h);
                for (var i = 0; i < w; i++)
                    for (var j = 0; j < h; j++)
                    {
                        if (map[x + i, y + j] != Directions.None)
                        {
                            done = false;
                        }
                    }
                if (!done) continue;
                for (var i = 0; i < w; i++)
                    for (var j = 0; j < h; j++)
                    {
                        var d = Directions.None;
                        if (i > 0) d |= Directions.West;
                        if (j > 0) d |= Directions.South;
                        if (i < w - 1) d |= Directions.East;
                        if (j < h - 1) d |= Directions.North;
                        map[x + i, y + j] = d;
                    }
                a += w * h;
            }

            var cells = map.Where((x, n) => x != Directions.None).ToArray();

            var grid = maze.Create(new RandomNumberGenerator(1), 20, 20, map);

            var s = grid.StringRepresentation();
            Console.Write(s);
            Console.ReadKey();
        }
    }
}