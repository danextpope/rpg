namespace CommonTests
{
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using FourZoas.RPG.Common;

    using Xunit;

    public class DirectionTests : BaseTests
    {
        private static readonly IEnumerable<object[]> oppositeDirection = GetDirection();

        private static readonly IEnumerable<object[]> oppositeDirections = GetDirections();

        public static IEnumerable<object[]> DirectionValues => Enumerable.Range(0, 6).Select(n => new object[] { (Direction)n, (Directions)(1 << n) });

        public static IEnumerable<object[]> OppositeDirection => oppositeDirection;

        public static IEnumerable<object[]> OppositeDirections => oppositeDirections;

        [Theory]
        [MemberData(nameof(DirectionValues))]
        public void MappingWorks(object left, object right)
        {
            Assert.Equal((Direction)left, Mapper.Map<Direction>((Directions)right));
            Assert.Equal((Directions)right, Mapper.Map<Directions>((Direction)left));
        }

        [Theory]
        [MemberData(nameof(OppositeDirection))]
        public void OppositeWorks1(Direction expected, Direction real) => Assert.Equal(expected, real.Opposite());
        [Theory]
        [MemberData(nameof(OppositeDirections))]
        public void OppositeWorks2(Directions expected, Directions real) => Assert.Equal(expected, real.Opposite());

        private static IEnumerable<object[]> GetDirection()
        {
            yield return new object[] { Direction.East, Direction.West };
            yield return new object[] { Direction.West, Direction.East };
            yield return new object[] { Direction.North, Direction.South };
            yield return new object[] { Direction.South, Direction.North };
            yield return new object[] { Direction.Up, Direction.Down };
            yield return new object[] { Direction.Down, Direction.Up };
        }

        private static IEnumerable<object[]> GetDirections()
        {
            yield return new object[] { Directions.East, Directions.West };
            yield return new object[] { Directions.West, Directions.East };
            yield return new object[] { Directions.North, Directions.South };
            yield return new object[] { Directions.South, Directions.North };
            yield return new object[] { Directions.Up, Directions.Down };
            yield return new object[] { Directions.Down, Directions.Up };
        }
    }
}