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
    /// <summary>Defines a mechanism for computing the modulus or remainder of two values.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    /// <typeparam name="TOther">The type that will divide <typeparamref name="T" />.</typeparam>
    /// <typeparam name="TResult">The type that contains the modulus or remainder of <typeparamref name="T" /> and <typeparamref name="TOther" />.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IModulusOperatorsCompatibility<T, TOther, TResult>
        where T : IModulusOperators<T, TOther, TResult>?, new()
    {
        /// <summary>Divides two values together to compute their modulus or remainder.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The modulus or remainder of <paramref name="left" /> divided-by <paramref name="right" />.</returns>
        /// <remarks>Use <c>left.Remainder(right)</c> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use left.Remainder(right) to ensure compatibility with all .NET targets.")]
        TResult Remainder(T? left, TOther? right);
    }
}

#endif
