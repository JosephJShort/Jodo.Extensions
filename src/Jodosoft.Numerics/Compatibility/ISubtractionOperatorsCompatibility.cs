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
using System.Diagnostics.CodeAnalysis;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines a mechanism for computing the difference of two values.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    /// <typeparam name="TOther">The type that will be subtracted from <typeparamref name="T" />.</typeparam>
    /// <typeparam name="TResult">The type that contains the difference of <typeparamref name="TOther" /> subtracted from <typeparamref name="T" />.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    [SuppressMessage("csharpsquid", "S3246:Generic type parameters should be co/contravariant when possible.", Justification = "Mirroring the .NET API.")]
    [SuppressMessage("csharpsquid", "S2436:Types and methods should not have too many generic parameters.", Justification = "Mirroring the .NET API.")]
    public interface ISubtractionOperatorsCompatibility<T, TOther, TResult>
        where T : ISubtractionOperators<T, TOther, TResult>?, new()
    {
        /// <summary>Subtracts two values to compute their difference.</summary>
        /// <param name="left">The value from which <paramref name="right" /> is subtracted.</param>
        /// <param name="right">The value which is subtracted from <paramref name="left" />.</param>
        /// <returns>The difference of <paramref name="right" /> subtracted from <paramref name="left" />.</returns>
        /// <remarks>Use <c>left.Subtract(right)</c> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use left.Subtract(right) to ensure compatibility with all .NET targets.")]
        TResult Subtract(T? left, TOther? right);
    }
}

#endif
