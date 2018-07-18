namespace MazeTester
{
    using System;
    using AutoMapper;
    using FourZoas.RPG.Common;
    using FourZoas.RPG.Common.Automapper;
    using FourZoas.RPG.Maze;

    class Program
    {
        static Program() => Mapper.Initialize(cfg => cfg.AddProfile<DirectionMapperProfile>());
        static void Main(string[] args)
        {
            var rnd = new Random();
            var maze = new GrowingTreeMaze<EmptyCell>(l=>rnd.Next(l.Count));
            var grid = maze.Create(new RandomNumberGenerator(1), 70, 25);
            //            var grid = new SquareGrid<EmptyCell>(3, 3);
            grid[0, 0].Exits |= Directions.East;
            grid[1, 0].Exits |= Directions.West;
            var s = grid.StringRepresentation();
            Console.Write(s);
            Console.ReadKey();
        }
    }
}
