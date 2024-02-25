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
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Provides static methods for trigonometric, logarithmic, and other common mathematical functions for
    /// implementations of <see cref="INumeric{TSelf}"/>
    /// </summary>
    public static class MathN
    {
        /// <summary>Computes the quotient and remainder of two values.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The quotient and remainder of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
        public static void DivRem<T>(T left, T right, out T quotient, out T remainder) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
        {
            (quotient, remainder) = T.DivRem(left, right);
        }
#else
        {
            quotient = DefaultInstance<T>.Value.Divide(left, right);
            remainder = DefaultInstance<T>.Value.Subtract(left, DefaultInstance<T>.Value.Multiply(quotient, right));
        }
#endif

#if HAS_VALUE_TUPLES
        /// <summary>Computes the quotient and remainder of two values.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The quotient and remainder of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
        public static (T Quotient, T Remainder) DivRem<T>(T left, T right) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
        => T.DivRem(left, right);
#else
        {
            T quotient = DefaultInstance<T>.Value.Divide(left, right);
            return (quotient, DefaultInstance<T>.Value.Subtract(left, DefaultInstance<T>.Value.Multiply(quotient, right)));
        }
#endif
#endif

        /// <summary>Computes <c>E</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>E</c> is raised.</param>
        /// <returns><c>E<sup><paramref name="x" /></sup></c></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Exp(x);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes <c>E</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>E</c> is raised.</param>
        /// <returns><c>E<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T ExpM1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ExpM1(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Subtract(DefaultInstance<T>.Value.Exp(x), DefaultInstance<T>.Value.One);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes <c>2</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>2</c> is raised.</param>
        /// <returns><c>2<sup><paramref name="x" /></sup></c></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp2<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp2(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Exp2(x);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes <c>2</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>2</c> is raised.</param>
        /// <returns><c>2<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T Exp2M1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp2M1(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Subtract(DefaultInstance<T>.Value.Exp2(x), DefaultInstance<T>.Value.One);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes <c>10</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>10</c> is raised.</param>
        /// <returns><c>10<sup><paramref name="x" /></sup></c></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp10<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp10(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Exp10(x);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes <c>10</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>10</c> is raised.</param>
        /// <returns><c>10<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T Exp10M1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp10M1(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Subtract(DefaultInstance<T>.Value.Exp10(x), DefaultInstance<T>.Value.One);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes the ceiling of a value.</summary>
        /// <param name="x">The value whose ceiling is to be computed.</param>
        /// <returns>The ceiling of <paramref name="x" />.</returns>
        public static T Ceiling<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Ceiling(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits: 0, (MidpointRounding)4); // MidpointRounding.ToPositiveInfinity
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes the floor of a value.</summary>
        /// <param name="x">The value whose floor is to be computed.</param>
        /// <returns>The floor of <paramref name="x" />.</returns>
        public static T Floor<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Floor(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits: 0, (MidpointRounding)3); // MidpointRounding.ToNegativeInfinity
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Rounds a value to the nearest integer using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <returns>The result of rounding <paramref name="x" /> to the nearest integer using the default rounding mode.</returns>
        public static T Round<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits: 0, MidpointRounding.ToEven);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Rounds a value to a specified number of fractional-digits using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="digits">The number of fractional digits to which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to <paramref name="digits" /> fractional-digits using the default rounding mode.</returns>
        public static T Round<T>(T x, int digits) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, digits);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits, MidpointRounding.ToEven);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Rounds a value to the nearest integer using the specified rounding mode.</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="mode">The mode under which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to the nearest integer using <paramref name="mode" />.</returns>
        public static T Round<T>(T x, MidpointRounding mode) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, mode);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits: 0, mode);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Rounds a value to a specified number of fractional-digits using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="digits">The number of fractional digits to which <paramref name="x" /> should be rounded.</param>
        /// <param name="mode">The mode under which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to <paramref name="digits" /> fractional-digits using <paramref name="mode" />.</returns>
        public static T Round<T>(T x, int digits, MidpointRounding mode) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, digits, mode);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits, mode);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Truncates a value.</summary>
        /// <param name="x">The value to truncate.</param>
        /// <returns>The truncation of <paramref name="x" />.</returns>
        public static T Truncate<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Truncate(x);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Round(x, digits: 0, (MidpointRounding)2); // MidpointRounding.ToZero
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Gets the mathematical constant <c>e</c>.</summary>
        public static T E<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.E;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.E;
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Gets the mathematical constant <c>pi</c>.</summary>
        public static T Pi<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Pi;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Pi;
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Gets the mathematical constant <c>tau</c>.</summary>
        public static T Tau<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Tau;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Tau;
#pragma warning restore CS0618 // Type or member is obsolete
#endif
    }
}
