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

// Justification: This is the preferred alternative API for obsolete interface members in Jodosoft.Numerics.Compatibility
#pragma warning disable CS0618 // Type or member is obsolete

namespace Jodosoft.Numerics
{
    /// <summary>
    /// Provides static methods for trigonometric, logarithmic, and other common mathematical functions for
    /// implementations of <see cref="INumeric{TSelf}"/>
    /// </summary>
    public static class MathN2
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
            quotient = left.Divide(right);
            remainder = left.Subtract(quotient.Multiply(right));
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
            T quotient = left.Divide(right);
            return (quotient, left.Subtract(quotient.Multiply(right)));
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
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp(x);
#endif

        /// <summary>Computes <c>E</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>E</c> is raised.</param>
        /// <returns><c>E<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T ExpM1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ExpM1(x);
#else
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp(x).Subtract(Number.One<T>());
#endif

        /// <summary>Computes <c>2</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>2</c> is raised.</param>
        /// <returns><c>2<sup><paramref name="x" /></sup></c></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp2<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp2(x);
#else
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp2(x);
#endif

        /// <summary>Computes <c>2</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>2</c> is raised.</param>
        /// <returns><c>2<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T Exp2M1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp2M1(x);
#else
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp2(x).Subtract(Number.One<T>());
#endif

        /// <summary>Computes <c>10</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>10</c> is raised.</param>
        /// <returns><c>10<sup><paramref name="x" /></sup></c></returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Exp10<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp10(x);
#else
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp10(x);
#endif

        /// <summary>Computes <c>10</c> raised to a given power and subtracts one.</summary>
        /// <param name="x">The power to which <c>10</c> is raised.</param>
        /// <returns><c>10<sup><paramref name="x" /></sup> - 1</c></returns>
        public static T Exp10M1<T>(T x) where T : IExponentialFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Exp10M1(x);
#else
            => SingleInstance.Of<T>().Provide<IExponentialFunctionsCompatibility<T>>().Exp10(x).Subtract(Number.One<T>());
#endif

        /// <summary>Computes the ceiling of a value.</summary>
        /// <param name="x">The value whose ceiling is to be computed.</param>
        /// <returns>The ceiling of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Ceiling<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Ceiling(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits: 0, (MidpointRounding)4); // MidpointRounding.ToPositiveInfinity
#endif

        /// <summary>Computes the floor of a value.</summary>
        /// <param name="x">The value whose floor is to be computed.</param>
        /// <returns>The floor of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Floor<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Floor(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits: 0, (MidpointRounding)3); // MidpointRounding.ToNegativeInfinity
#endif

        /// <summary>Rounds a value to the nearest integer using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <returns>The result of rounding <paramref name="x" /> to the nearest integer using the default rounding mode.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits: 0, MidpointRounding.ToEven);
#endif

        /// <summary>Rounds a value to a specified number of fractional-digits using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="digits">The number of fractional digits to which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to <paramref name="digits" /> fractional-digits using the default rounding mode.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round<T>(T x, int digits) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, digits);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits, MidpointRounding.ToEven);
#endif

        /// <summary>Rounds a value to the nearest integer using the specified rounding mode.</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="mode">The mode under which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to the nearest integer using <paramref name="mode" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round<T>(T x, MidpointRounding mode) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, mode);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits: 0, mode);
#endif

        /// <summary>Rounds a value to a specified number of fractional-digits using the default rounding mode (<see cref="MidpointRounding.ToEven" />).</summary>
        /// <param name="x">The value to round.</param>
        /// <param name="digits">The number of fractional digits to which <paramref name="x" /> should be rounded.</param>
        /// <param name="mode">The mode under which <paramref name="x" /> should be rounded.</param>
        /// <returns>The result of rounding <paramref name="x" /> to <paramref name="digits" /> fractional-digits using <paramref name="mode" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Round<T>(T x, int digits, MidpointRounding mode) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Round(x, digits, mode);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits, mode);
#endif

        /// <summary>Truncates a value.</summary>
        /// <param name="x">The value to truncate.</param>
        /// <returns>The truncation of <paramref name="x" />.</returns>
        public static T Truncate<T>(T x) where T : IFloatingPoint<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Truncate(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointCompatibility<T>>().Round(x, digits: 0, (MidpointRounding)2); // MidpointRounding.ToZero
#endif

        /// <summary>Gets the mathematical constant <c>e</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T E<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.E;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointConstantsCompatibility<T>>().E;
#endif

        /// <summary>Gets the mathematical constant <c>pi</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Pi<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Pi;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointConstantsCompatibility<T>>().Pi;
#endif

        /// <summary>Gets the mathematical constant <c>tau</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Tau<T>() where T : IFloatingPointConstants<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Tau;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointConstantsCompatibility<T>>().Tau;
#endif

        /// <summary>Computes the hyperbolic arc-cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-cosine is to be computed.</param>
        /// <returns>The hyperbolic arc-cosine of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Acosh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Acosh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Acosh(x);
#endif

        /// <summary>Computes the hyperbolic arc-sine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-sine is to be computed.</param>
        /// <returns>The hyperbolic arc-sine of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Asinh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Asinh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Asinh(x);
#endif

        /// <summary>Computes the hyperbolic arc-tangent of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-tangent is to be computed.</param>
        /// <returns>The hyperbolic arc-tangent of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atanh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Atanh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Atanh(x);
#endif

        /// <summary>Computes the hyperbolic cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic cosine is to be computed.</param>
        /// <returns>The hyperbolic cosine of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Cosh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Cosh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Cosh(x);
#endif

        /// <summary>Computes the hyperbolic sine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic sine is to be computed.</param>
        /// <returns>The hyperbolic sine of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Sinh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Sinh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Sinh(x);
#endif

        /// <summary>Computes the hyperbolic tangent of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic tangent is to be computed.</param>
        /// <returns>The hyperbolic tangent of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Tanh<T>(T x) where T : IHyperbolicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Tanh(x);
#else
            => SingleInstance.Of<T>().Provide<IHyperbolicFunctionsCompatibility<T>>().Tanh(x);
#endif

        /// <summary>Computes the natural (<c>base-E</c>) logarithm of a value.</summary>
        /// <param name="x">The value whose natural logarithm is to be computed.</param>
        /// <returns><c>log<sub>e</sub>(<paramref name="x" />)</c></returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log(x);
#endif

        /// <summary>Computes the logarithm of a value in the specified base.</summary>
        /// <param name="x">The value whose logarithm is to be computed.</param>
        /// <param name="newBase">The base in which the logarithm is to be computed.</param>
        /// <returns><c>log<sub><paramref name="newBase" /></sub>(<paramref name="x" />)</c></returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log<T>(T x, T newBase) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log(x, newBase);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log(x, newBase);
#endif

        /// <summary>Computes the natural (<c>base-E</c>) logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the natural logarithm.</param>
        /// <returns><c>log<sub>e</sub>(<paramref name="x" /> + 1)</c></returns>
        public static T LogP1<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.LogP1(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log(x.Add(Number.One<T>()));
#endif

        /// <summary>Computes the base-2 logarithm of a value.</summary>
        /// <param name="x">The value whose base-2 logarithm is to be computed.</param>
        /// <returns><c>log<sub>2</sub>(<paramref name="x" />)</c></returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log2<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log2(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log2(x);
#endif

        /// <summary>Computes the base-2 logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the base-2 logarithm.</param>
        /// <returns><c>log<sub>2</sub>(<paramref name="x" /> + 1)</c></returns>
        public static T Log2P1<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log2P1(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log2(x.Add(Number.One<T>()));
#endif

        /// <summary>Computes the base-10 logarithm of a value.</summary>
        /// <param name="x">The value whose base-10 logarithm is to be computed.</param>
        /// <returns><c>log<sub>10</sub>(<paramref name="x" />)</c></returns>

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log10<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log10(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log10(x);
#endif

        /// <summary>Computes the base-10 logarithm of a value plus one.</summary>
        /// <param name="x">The value to which one is added before computing the base-10 logarithm.</param>
        /// <returns><c>log<sub>10</sub>(<paramref name="x" /> + 1)</c></returns>
        public static T Log10P1<T>(T x) where T : ILogarithmicFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log10P1(x);
#else
            => SingleInstance.Of<T>().Provide<ILogarithmicFunctionsCompatibility<T>>().Log10(x.Add(Number.One<T>()));
#endif

        /// <summary>Computes the cube-root of a value.</summary>
        /// <param name="x">The value whose cube-root is to be computed.</param>
        /// <returns>The cube-root of <paramref name="x" />.</returns>
        public static T Cbrt<T>(T x) where T : IRootFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Cbrt(x);
#else
            => SingleInstance.Of<T>().Provide<IRootFunctionsCompatibility<T>>().Cbrt(x);
#endif

        /// <summary>Computes the hypotenuse given two values representing the lengths of the shorter sides in a right-angled triangle.</summary>
        /// <param name="x">The value to square and add to <paramref name="y" />.</param>
        /// <param name="y">The value to square and add to <paramref name="x" />.</param>
        /// <returns>The square root of <paramref name="x" />-squared plus <paramref name="y" />-squared.</returns>
        public static T Hypot<T>(T x, T y) where T : IRootFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Hypot(x, y);
#else
            => SingleInstance.Of<T>().Provide<IRootFunctionsCompatibility<T>>().Hypot(x, y);
#endif

        /// <summary>Computes the n-th root of a value.</summary>
        /// <param name="x">The value whose <paramref name="n" />-th root is to be computed.</param>
        /// <param name="n">The degree of the root to be computed.</param>
        /// <returns>The <paramref name="n" />-th root of <paramref name="x" />.</returns>
        public static T RootN<T>(T x, int n) where T : IRootFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.RootN(x, n);
#else
            => SingleInstance.Of<T>().Provide<IRootFunctionsCompatibility<T>>().RootN(x, n);
#endif

        /// <summary>Computes the square-root of a value.</summary>
        /// <param name="x">The value whose square-root is to be computed.</param>
        /// <returns>The square-root of <paramref name="x" />.</returns>
        public static T Sqrt<T>(T x) where T : IRootFunctions<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Sqrt(x);
#else
            => SingleInstance.Of<T>().Provide<IRootFunctionsCompatibility<T>>().Sqrt(x);
#endif
    }
}

#pragma warning restore CS0618 // Type or member is obsolete
