namespace FourZoas.RPG.Common
{
    /// <summary>A random number generator.</summary>
    public interface IRandom
    {
        /// <summary>Gets the random number seed.</summary>
        /// <value>The random number seed.</value>
        int Seed { get; }

        /// <summary>Gets a random interger from 0 to <see cref="int.MaxValue"/>.</summary>
        /// <returns>A random interger from 0 to <see cref="int.MaxValue"/>.</returns>
        int Get();

        /// <summary>Gets a random integer from 0 to <c>maxValue</c>.</summary>
        /// <param name="maxValue">The exclusive maximum value.</param>
        /// <returns>A random integer from 0 to <c>maxValue</c>.</returns>
        int Get(int maxValue);

        /// <summary>Gets a random number from <c>minValue</c> to <c>maxValue</c>.</summary>
        /// <param name="minValue">The inclusive minimum value.</param>
        /// <param name="maxValue">The exclusive maximum value.</param>
        /// <returns>A random number from <c>minValue</c> to <c>maxValue</c>.</returns>
        int Get(int minValue, int maxValue);

        /// <summary>Gets a random double value from <c>0</c> to <c>1</c>.</summary>
        /// <returns>A random double value from <c>0</c> to <c>1</c>.</returns>
        double GetDouble();

        /// <summary>Resets this instance.</summary>
        void Reset();
    }
}