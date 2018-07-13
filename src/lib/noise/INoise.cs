namespace noise
{
    /// <summary>A noise interface.</summary>
    public interface INoise
    {
        /// <summary>Gets the random number seed.</summary>
        /// <value>The random number seed.</value>
        int Seed { get; }

        /// <summary>Gets the value of this noise in one dimension at the given coordinates.</summary>
        /// <param name="x">The <c>x</c> coordinate.</param>
        /// <returns>The value of one dimensional noise at the given coordinate.</returns>
        double GetValue(double x);

        /// <summary>Gets the value of this noise in two dimensions at the given coordinates.</summary>
        /// <param name="x">The <c>x</c> coordinate.</param>
        /// <param name="y">The <c>y</c> coordinate.</param>
        /// <returns>The value of two dimensional noise at the given coordinates.</returns>
        double GetValue(double x, double y);

        /// <summary>Gets the value of this noise in three dimensions at the given coordinates.</summary>
        /// <param name="x">The <c>x</c> coordinate.</param>
        /// <param name="y">The <c>y</c> coordinate.</param>
        /// <param name="z">The <c>z</c> coordinate.</param>
        /// <returns>The value of three dimensional noise at the given coordinates.</returns>
        double GetValue(double x, double y, double z);

        /// <summary>Gets the value of this noise in four dimensions at the given coordinates.</summary>
        /// <param name="x">The <c>x</c> coordinate.</param>
        /// <param name="y">The <c>y</c> coordinate.</param>
        /// <param name="z">The <c>z</c> coordinate.</param>
        /// <param name="z">The <c>w</c> coordinate.</param>
        /// <returns>The value of four dimensional noise at the given coordinates.</returns>
        double GetValue(double x, double y, double z, double w);
    }
}