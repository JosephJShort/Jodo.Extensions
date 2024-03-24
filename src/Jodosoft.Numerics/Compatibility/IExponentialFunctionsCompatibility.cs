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
    /// <summary>Defines support for exponential functions.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    public interface IExponentialFunctionsCompatibility<T>
        where T : IExponentialFunctions<T>?, new()
    {
        /// <summary>Computes <c>E</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>E</c> is raised.</param>
        /// <returns><c>E<sup><paramref name="x" /></sup></c></returns>
        /// <remarks>Use <see cref="MathN.Exp{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Exp to ensure forward-compatibility.")]
        T Exp(T x);

        /// <summary>Computes <c>2</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>2</c> is raised.</param>
        /// <returns><c>2<sup><paramref name="x" /></sup></c></returns>
        /// <remarks>Use <see cref="MathN.Exp2{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Exp2 to ensure forward-compatibility.")]
        T Exp2(T x);

        /// <summary>Computes <c>10</c> raised to a given power.</summary>
        /// <param name="x">The power to which <c>10</c> is raised.</param>
        /// <returns><c>10<sup><paramref name="x" /></sup></c></returns>
        /// <remarks>Use <see cref="MathN.Exp10{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.MathN.Exp10 to ensure forward-compatibility.")]
        T Exp10(T x);
    }
}

#endif
