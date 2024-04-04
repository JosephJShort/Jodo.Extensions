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

using System;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines an IEEE 754 floating-point type.</summary>
    /// <typeparam name="T">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IFloatingPointIeee754Compatibility<T>
            where T : IFloatingPointIeee754<T>?, new()
    {
        /// <summary>Gets the smallest value such that can be added to <c>0</c> that does not result in <c>0</c>.</summary>
        /// <remarks>Use <see cref="Number.Epsilon{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.Epsilon to ensure forward-compatibility.")]
        T Epsilon { get; }

        /// <summary>Gets a value that represents <c>NaN</c>.</summary>
        /// <remarks>Use <see cref="Number.NaN{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.NaN to ensure forward-compatibility.")]
        T NaN { get; }

        /// <summary>Gets a value that represents negative <c>infinity</c>.</summary>
        /// <remarks>Use <see cref="Number.NegativeInfinity{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.NegativeInfinity to ensure forward-compatibility.")]
        T NegativeInfinity { get; }

        /// <summary>Gets a value that represents negative <c>zero</c>.</summary>
        /// <remarks>Use <see cref="Number.NegativeZero{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.NegativeZero to ensure forward-compatibility.")]
        T NegativeZero { get; }

        /// <summary>Gets a value that represents positive <c>infinity</c>.</summary>
        /// <remarks>Use <see cref="Number.PositiveInfinity{T}"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.PositiveInfinity to ensure forward-compatibility.")]
        T PositiveInfinity { get; }

        /// <summary>Computes the arc-tangent for the quotient of two values.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arctan(y / x)</c> in the interval <c>[-PI, +PI]</c> radians.</remarks>
        /// <remarks>Use <see cref="Number.Atan2{T}(T, T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.Atan2 to ensure forward-compatibility.")]
        T Atan2(T y, T x);

        /// <summary>Computes the arc-tangent for the quotient of two values and divides the result by <c>pi</c>.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arctan(y / x) / PI</c> in the interval <c>[-1, +1]</c>.</remarks>
        /// <remarks>Use <see cref="Number.Atan2Pi{T}(T, T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.Atan2Pi to ensure forward-compatibility.")]
        T Atan2Pi(T y, T x);

        /// <summary>Decrements a value to the largest value that compares less than a given value.</summary>
        /// <param name="x">The value to be bitwise decremented.</param>
        /// <returns>The largest value that compares less than <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="Number.BitDecrement{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.BitDecrement to ensure forward-compatibility.")]
        T BitDecrement(T x);

        /// <summary>Increments a value to the smallest value that compares greater than a given value.</summary>
        /// <param name="x">The value to be bitwise incremented.</param>
        /// <returns>The smallest value that compares greater than <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="Number.BitIncrement{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.BitIncrement to ensure forward-compatibility.")]
        T BitIncrement(T x);

        /// <summary>Computes the fused multiply-add of three values.</summary>
        /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
        /// <param name="right">The value which multiplies <paramref name="left" />.</param>
        /// <param name="addend">The value that is added to the product of <paramref name="left" /> and <paramref name="right" />.</param>
        /// <returns>The result of <paramref name="left" /> times <paramref name="right" /> plus <paramref name="addend" /> computed as one ternary operation.</returns>
        /// <remarks>Use <see cref="Number.FusedMultiplyAdd{T}(T, T, T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.FusedMultiplyAdd to ensure forward-compatibility.")]
        T FusedMultiplyAdd(T left, T right, T addend);

        /// <summary>Computes the remainder of two values as specified by IEEE 754.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The remainder of <paramref name="left" /> divided-by <paramref name="right" /> as specified by IEEE 754.</returns>
        /// <remarks>Use <see cref="Number.Ieee754Remainder{T}(T, T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.Ieee754Remainder to ensure forward-compatibility.")]
        T Ieee754Remainder(T left, T right);

        /// <summary>Computes the integer logarithm of a value.</summary>
        /// <param name="x">The value whose integer logarithm is to be computed.</param>
        /// <returns>The integer logarithm of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="Number.ILogB{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.ILogB to ensure forward-compatibility.")]
        int ILogB(T x);

        /// <summary>Computes the product of a value and its base-radix raised to the specified power.</summary>
        /// <param name="x">The value which base-radix raised to the power of <paramref name="n" /> multiplies.</param>
        /// <param name="n">The value to which base-radix is raised before multipliying <paramref name="x" />.</param>
        /// <returns>The product of <paramref name="x" /> and base-radix raised to the power of <paramref name="n" />.</returns>
        /// <remarks>Use <see cref="Number.ScaleB{T}(T, int)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.ScaleB to ensure forward-compatibility.")]
        T ScaleB(T x, int n);
    }
}

#endif
