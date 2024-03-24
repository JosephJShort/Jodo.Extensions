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
    /// <summary>Defines support for trigonometric functions.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface ITrigonometricFunctionsCompatibility<T>
        where T : ITrigonometricFunctions<T>?, new()
    {
        /// <summary>Computes the arc-cosine of a value.</summary>
        /// <param name="x">The value whose arc-cosine is to be computed.</param>
        /// <returns>The arc-cosine of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arccos(x)</c> in the interval <c>[+0, +π]</c> radians.</remarks>
        T Acos(T x);

        /// <summary>Computes the arc-cosine of a value and divides the result by <c>pi</c>.</summary>
        /// <param name="x">The value whose arc-cosine is to be computed.</param>
        /// <returns>The arc-cosine of <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arccos(x) / π</c> in the interval <c>[-0.5, +0.5]</c>.</remarks>
        T AcosPi(T x);

        /// <summary>Computes the arc-sine of a value.</summary>
        /// <param name="x">The value whose arc-sine is to be computed.</param>
        /// <returns>The arc-sine of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arcsin(x)</c> in the interval <c>[-π / 2, +π / 2]</c> radians.</remarks>
        T Asin(T x);

        /// <summary>Computes the arc-sine of a value and divides the result by <c>pi</c>.</summary>
        /// <param name="x">The value whose arc-sine is to be computed.</param>
        /// <returns>The arc-sine of <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arcsin(x) / π</c> in the interval <c>[-0.5, +0.5]</c>.</remarks>
        T AsinPi(T x);

        /// <summary>Computes the arc-tangent of a value.</summary>
        /// <param name="x">The value whose arc-tangent is to be computed.</param>
        /// <returns>The arc-tangent of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arctan(x)</c> in the interval <c>[-π / 2, +π / 2]</c> radians.</remarks>
        T Atan(T x);

        /// <summary>Computes the arc-tangent of a value and divides the result by pi.</summary>
        /// <param name="x">The value whose arc-tangent is to be computed.</param>
        /// <returns>The arc-tangent of <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arctan(x) / π</c> in the interval <c>[-0.5, +0.5]</c>.</remarks>
        T AtanPi(T x);

        /// <summary>Computes the cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose cosine is to be computed.</param>
        /// <returns>The cosine of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>cos(x)</c>.</remarks>
        T Cos(T x);

        /// <summary>Computes the cosine of a value that has been multipled by <c>pi</c>.</summary>
        /// <param name="x">The value, in half-revolutions, whose cosine is to be computed.</param>
        /// <returns>The cosine of <paramref name="x" /> multiplied-by <c>pi</c>.</returns>
        /// <remarks>This computes <c>cos(x * π)</c>.</remarks>
        T CosPi(T x);

        /// <summary>Computes the sine of a value.</summary>
        /// <param name="x">The value, in radians, whose sine is to be computed.</param>
        /// <returns>The sine of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>sin(x)</c>.</remarks>
        T Sin(T x);

        /// <summary>Computes the sine and cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose sine and cosine are to be computed.</param>
        /// <returns>The sine and cosine of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>(sin(x), cos(x))</c>.</remarks>
        Tuple<T, T> SinCos(T x);

        /// <summary>Computes the sine and cosine of a value that has been multiplied by <c>pi</c>.</summary>
        /// <param name="x">The value, in half-revolutions, that is multipled by <c>pi</c> before computing its sine and cosine.</param>
        /// <returns>The sine and cosine of<paramref name="x" /> multiplied-by <c>pi</c>.</returns>
        /// <remarks>This computes <c>(sin(x * π), cos(x * π))</c>.</remarks>
        Tuple<T, T> SinCosPi(T x);

        /// <summary>Computes the sine of a value that has been multiplied by <c>pi</c>.</summary>
        /// <param name="x">The value, in half-revolutions, that is multipled by <c>pi</c> before computing its sine.</param>
        /// <returns>The sine of <paramref name="x" /> multiplied-by <c>pi</c>.</returns>
        /// <remarks>This computes <c>sin(x * π)</c>.</remarks>
        T SinPi(T x);

        /// <summary>Computes the tangent of a value.</summary>
        /// <param name="x">The value, in radians, whose tangent is to be computed.</param>
        /// <returns>The tangent of <paramref name="x" />.</returns>
        /// <remarks>This computes <c>tan(x)</c>.</remarks>
        T Tan(T x);

        /// <summary>Computes the tangent of a value that has been multipled by <c>pi</c>.</summary>
        /// <param name="x">The value, in half-revolutions, that is multipled by <c>pi</c> before computing its tangent.</param>
        /// <returns>The tangent of <paramref name="x" /> multiplied-by <c>pi</c>.</returns>
        /// <remarks>This computes <c>tan(x * π)</c>.</remarks>
        T TanPi(T x);
    }
}

#endif
