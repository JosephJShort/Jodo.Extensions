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

using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics.Compatibility
{
    public static class ComparisonOperatorsExtensions
    {
        /// <summary>Compares two values to determine which is less.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is less than <paramref name="right" />; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThan<T, TOther, TResult>(this T left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left < right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IComparisonOperatorsCompatibility<T, TOther, TResult>>().IsLessThan(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsLessThan{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThan<T, TOther, TResult>(this IComparisonOperators<T, TOther, TResult> left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
            => IsLessThan<T, TOther, TResult>((T)left, right);

        /// <summary>Compares two values to determine which is less or equal.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is less than or equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThanOrEqualTo<T, TOther, TResult>(this T left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left <= right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IComparisonOperatorsCompatibility<T, TOther, TResult>>().IsLessThanOrEqualTo(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsLessThanOrEqualTo{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsLessThanOrEqualTo<T, TOther, TResult>(this IComparisonOperators<T, TOther, TResult> left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
            => IsLessThanOrEqualTo<T, TOther, TResult>((T)left, right);

        /// <summary>Compares two values to determine which is greater.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is greater than <paramref name="right" />; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThan<T, TOther, TResult>(this T left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left > right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IComparisonOperatorsCompatibility<T, TOther, TResult>>().IsGreaterThan(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsGreaterThan{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThan<T, TOther, TResult>(this IComparisonOperators<T, TOther, TResult> left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
            => IsGreaterThan<T, TOther, TResult>((T)left, right);

        /// <summary>Compares two values to determine which is greater or equal.</summary>
        /// <param name="left">The value to compare with <paramref name="right" />.</param>
        /// <param name="right">The value to compare with <paramref name="left" />.</param>
        /// <returns><c>true</c> if <paramref name="left" /> is greater than or equal to <paramref name="right" />; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThanOrEqualTo<T, TOther, TResult>(this T left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left >= right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IComparisonOperatorsCompatibility<T, TOther, TResult>>().IsGreaterThanOrEqualTo(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="IsGreaterThanOrEqualTo{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult IsGreaterThanOrEqualTo<T, TOther, TResult>(this IComparisonOperators<T, TOther, TResult> left, TOther right) where T : IComparisonOperators<T, TOther, TResult>, new()
            => IsGreaterThanOrEqualTo<T, TOther, TResult>((T)left, right);
    }
}
