﻿// Copyright (c) 2023 Joe Lawry-Short
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

using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics.Compatibility
{
    public static class MultiplyOperatorsExtensions
    {
        /// <summary>Multiplies two values together to compute their product.</summary>
        /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
        /// <param name="right">The value which multiplies <paramref name="left" />.</param>
        /// <returns>The product of <paramref name="left" /> multiplied-by <paramref name="right" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Multiply<T, TOther, TResult>(this T left, TOther right) where T : IMultiplyOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left * right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IMultiplyOperatorsCompatibility<T, TOther, TResult>>().Multiply(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="Multiply{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult Multiply<T, TOther, TResult>(this IMultiplyOperators<T, TOther, TResult> left, TOther right) where T : IMultiplyOperators<T, TOther, TResult>, new()
            => Multiply<T, TOther, TResult>((T)left, right);
    }
}
