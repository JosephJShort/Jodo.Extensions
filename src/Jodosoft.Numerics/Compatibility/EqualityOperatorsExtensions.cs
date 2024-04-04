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
    public static class EqualityOperatorsExtensions
    {
        /// <summary>Compares two values to determine equality.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsEqualTo<T, TOther, TResult>(this T left, TOther right) where T : IEqualityOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left == right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IEqualityOperatorsCompatibility<T, TOther, TResult>>().IsEqualTo(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsEqualTo{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsEqualTo<T, TOther, TResult>(this IEqualityOperators<T, TOther, TResult> left, TOther right) where T : IEqualityOperators<T, TOther, TResult>, new()
            => IsEqualTo<T, TOther, TResult>((T)left, right);

        /// <summary>Compares two values to determine inequality.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is not equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsNotEqualTo<T, TOther, TResult>(this T left, TOther right) where T : IEqualityOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left != right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IEqualityOperatorsCompatibility<T, TOther, TResult>>().IsNotEqualTo(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsNotEqualTo{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsNotEqualTo<T, TOther, TResult>(this IEqualityOperators<T, TOther, TResult> left, TOther right) where T : IEqualityOperators<T, TOther, TResult>, new()
            => IsNotEqualTo<T, TOther, TResult>((T)left, right);
    }
}
