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

using System;

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines support for hyperbolic functions.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface IHyperbolicFunctionsCompatibility<T>
        where T : IHyperbolicFunctions<T>?, new()
    {
        /// <summary>Computes the hyperbolic arc-cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-cosine is to be computed.</param>
        /// <returns>The hyperbolic arc-cosine of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Acosh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Acosh to ensure forward-compatibility.")]
        T Acosh(T x);

        /// <summary>Computes the hyperbolic arc-sine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-sine is to be computed.</param>
        /// <returns>The hyperbolic arc-sine of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Asinh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Asinh to ensure forward-compatibility.")]
        T Asinh(T x);

        /// <summary>Computes the hyperbolic arc-tangent of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic arc-tangent is to be computed.</param>
        /// <returns>The hyperbolic arc-tangent of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Atanh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Atanh to ensure forward-compatibility.")]
        T Atanh(T x);

        /// <summary>Computes the hyperbolic cosine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic cosine is to be computed.</param>
        /// <returns>The hyperbolic cosine of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Cosh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Cosh to ensure forward-compatibility.")]
        T Cosh(T x);

        /// <summary>Computes the hyperbolic sine of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic sine is to be computed.</param>
        /// <returns>The hyperbolic sine of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Sinh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Sinh to ensure forward-compatibility.")]
        T Sinh(T x);

        /// <summary>Computes the hyperbolic tangent of a value.</summary>
        /// <param name="x">The value, in radians, whose hyperbolic tangent is to be computed.</param>
        /// <returns>The hyperbolic tangent of <paramref name="x" />.</returns>
        /// <remarks>Use <see cref="MathN.Tanh{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Tanh to ensure forward-compatibility.")]
        T Tanh(T x);
    }
}

#endif
