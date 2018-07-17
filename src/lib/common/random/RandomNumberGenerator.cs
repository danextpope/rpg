namespace FourZoas.RPG.Common
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>A random number generator wrapper around <see cref="Random"/>.</summary>
    /// <seealso cref="IRandom"/>
    public class RandomNumberGenerator : IRandom
    {
        private Random random;

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNumberGenerator"/> class with a random
        /// seed value.
        /// </summary>
        public RandomNumberGenerator() : this(new Random().Next())
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RandomNumberGenerator"/> class with the
        /// given seed value.
        /// </summary>
        /// <param name="seed">The seed.</param>
        public RandomNumberGenerator(int seed)
        {
            Seed = seed;
            random = new Random(seed);
        }

        /// <summary>Gets the random number seed.</summary>
        /// <value>The random number seed.</value>
        public int Seed { get; }

        /// <summary>Gets a random interger from 0 to <see cref="int.MaxValue"/>.</summary>
        /// <returns>A random interger from 0 to <see cref="int.MaxValue"/>.</returns>
        public int Get() => random.Next();

        /// <summary>Gets a random integer from 0 to <c>maxValue</c>.</summary>
        /// <param name="maxValue">The exclusive maximum value.</param>
        /// <returns>A random integer from 0 to <c>maxValue</c>.</returns>
        public int Get(int maxValue) => random.Next(maxValue);

        /// <summary>Gets a random number from <c>minValue</c> to <c>maxValue</c>.</summary>
        /// <param name="minValue">The inclusive minimum value.</param>
        /// <param name="maxValue">The exclusive maximum value.</param>
        /// <returns>A random number from <c>minValue</c> to <c>maxValue</c>.</returns>
        public int Get(int minValue, int maxValue) => random.Next(minValue, maxValue);

        /// <summary>Gets a random double value from <c>0</c> to <c>1</c>.</summary>
        /// <returns>A random double value from <c>0</c> to <c>1</c>.</returns>
        public double GetDouble() => random.NextDouble();

        /// <summary>Picks an item at random from an <see cref="T:System.Collections.Generic.IEnumerable`1"/>.</summary>
        /// <typeparam name="T">The type stored in the collection.</typeparam>
        /// <param name="enumerable">The enumerable.</param>
        /// <returns>A random element from the collection.</returns>
        /// <exception cref="ArgumentOutOfRangeException">enumerable - Collection is empty.</exception>
        public T RandomItem<T>(IEnumerable<T> enumerable)
        {
            var n = enumerable?.Count() ?? 0;
            if (n == 0) throw new ArgumentOutOfRangeException(nameof(enumerable), "Collection is empty.");
            return enumerable.Skip(Get(n)).First();
        }

        /// <summary>Resets this instance.</summary>
        public void Reset() => random = new Random(Seed);
    }
}