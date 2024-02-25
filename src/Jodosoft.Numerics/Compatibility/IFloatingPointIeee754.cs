// Copyright (c) 2023 Joe Lawry-Short
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to
// deal in the Software without restriction, including without limitation the
// rights to use, copy, modify, merge, publish, distribute, sublicense, and/or
// sell copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
// FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS
// IN THE SOFTWARE.

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines an IEEE 754 floating-point type.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    public interface IFloatingPointIeee754<TSelf>
            : IExponentialFunctions<TSelf>,
              IFloatingPoint<TSelf>,
              IHyperbolicFunctions<TSelf>,
              ILogarithmicFunctions<TSelf>,
              IPowerFunctions<TSelf>,
              IRootFunctions<TSelf>,
              ITrigonometricFunctions<TSelf>
            where TSelf : IFloatingPointIeee754<TSelf>?, new()
    {
        /// <summary>Gets the smallest value such that can be added to <c>0</c> that does not result in <c>0</c>.</summary>
        TSelf Epsilon { get; }

        /// <summary>Gets a value that represents <c>NaN</c>.</summary>
        TSelf NaN { get; }

        /// <summary>Gets a value that represents negative <c>infinity</c>.</summary>
        TSelf NegativeInfinity { get; }

        /// <summary>Gets a value that represents negative <c>zero</c>.</summary>
        TSelf NegativeZero { get; }

        /// <summary>Gets a value that represents positive <c>infinity</c>.</summary>
        TSelf PositiveInfinity { get; }

        /// <summary>Computes the arc-tangent for the quotient of two values.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arctan(y / x)</c> in the interval <c>[-π, +π]</c> radians.</remarks>
        TSelf Atan2(TSelf y, TSelf x);

        /// <summary>Computes the arc-tangent for the quotient of two values and divides the result by <c>pi</c>.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arctan(y / x) / π</c> in the interval <c>[-1, +1]</c>.</remarks>
        TSelf Atan2Pi(TSelf y, TSelf x);

        /// <summary>Decrements a value to the largest value that compares less than a given value.</summary>
        /// <param name="x">The value to be bitwise decremented.</param>
        /// <returns>The largest value that compares less than <paramref name="x" />.</returns>
        TSelf BitDecrement(TSelf x);

        /// <summary>Increments a value to the smallest value that compares greater than a given value.</summary>
        /// <param name="x">The value to be bitwise incremented.</param>
        /// <returns>The smallest value that compares greater than <paramref name="x" />.</returns>
        TSelf BitIncrement(TSelf x);

        /// <summary>Computes the fused multiply-add of three values.</summary>
        /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
        /// <param name="right">The value which multiplies <paramref name="left" />.</param>
        /// <param name="addend">The value that is added to the product of <paramref name="left" /> and <paramref name="right" />.</param>
        /// <returns>The result of <paramref name="left" /> times <paramref name="right" /> plus <paramref name="addend" /> computed as one ternary operation.</returns>
        TSelf FusedMultiplyAdd(TSelf left, TSelf right, TSelf addend);

        /// <summary>Computes the remainder of two values as specified by IEEE 754.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The remainder of <paramref name="left" /> divided-by <paramref name="right" /> as specified by IEEE 754.</returns>
        TSelf Ieee754Remainder(TSelf left, TSelf right);

        /// <summary>Computes the integer logarithm of a value.</summary>
        /// <param name="x">The value whose integer logarithm is to be computed.</param>
        /// <returns>The integer logarithm of <paramref name="x" />.</returns>
        int ILogB(TSelf x);

        /// <summary>Computes the product of a value and its base-radix raised to the specified power.</summary>
        /// <param name="x">The value which base-radix raised to the power of <paramref name="n" /> multiplies.</param>
        /// <param name="n">The value to which base-radix is raised before multipliying <paramref name="x" />.</param>
        /// <returns>The product of <paramref name="x" /> and base-radix raised to the power of <paramref name="n" />.</returns>
        TSelf ScaleB(TSelf x, int n);

        /*
                    /// <summary>Computes an estimate of the reciprocal of a value.</summary>
                    /// <param name="x">The value whose estimate of the reciprocal is to be computed.</param>
                    /// <returns>An estimate of the reciprocal of <paramref name="x" />.</returns>
                    static virtual TSelf ReciprocalEstimate(TSelf x) => TSelf.One / x;

                    /// <summary>Computes an estimate of the reciprocal square root of a value.</summary>
                    /// <param name="x">The value whose estimate of the reciprocal square root is to be computed.</param>
                    /// <returns>An estimate of the reciprocal square root of <paramref name="x" />.</returns>
                    static virtual TSelf ReciprocalSqrtEstimate(TSelf x) => TSelf.One / TSelf.Sqrt(x);
        */
    }
}

#endif
