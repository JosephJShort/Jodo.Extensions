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
    /// <summary>Defines support for root functions.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface IRootFunctionsCompatibility<T>
        where T : IRootFunctions<T>?, new()
    {
        /// <summary>Computes the cube-root of a value.</summary>
        /// <param name="x">The value whose cube-root is to be computed.</param>
        /// <returns>The cube-root of <paramref name="x" />.</returns>
        T Cbrt(T x);

        /// <summary>Computes the hypotenuse given two values representing the lengths of the shorter sides in a right-angled triangle.</summary>
        /// <param name="x">The value to square and add to <paramref name="y" />.</param>
        /// <param name="y">The value to square and add to <paramref name="x" />.</param>
        /// <returns>The square root of <paramref name="x" />-squared plus <paramref name="y" />-squared.</returns>
        T Hypot(T x, T y);

        /// <summary>Computes the n-th root of a value.</summary>
        /// <param name="x">The value whose <paramref name="n" />-th root is to be computed.</param>
        /// <param name="n">The degree of the root to be computed.</param>
        /// <returns>The <paramref name="n" />-th root of <paramref name="x" />.</returns>
        T RootN(T x, int n);

        /// <summary>Computes the square-root of a value.</summary>
        /// <param name="x">The value whose square-root is to be computed.</param>
        /// <returns>The square-root of <paramref name="x" />.</returns>
        T Sqrt(T x);
    }
}

#endif
