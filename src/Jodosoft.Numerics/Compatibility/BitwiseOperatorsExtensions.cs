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
    public static class BitwiseOperatorsExtensions
    {
        /// <summary>Computes the bitwise-and of two values.</summary>
        /// <param name="left">The value to and with <paramref name="right" />.</param>
        /// <param name="right">The value to and with <paramref name="left" />.</param>
        /// <returns>The bitwise-and of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalAnd<T, TOther, TResult>(this T left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left & right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IBitwiseOperatorsCompatibility<T, TOther, TResult>>().LogicalAnd(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="LogicalAnd{T, TOther, TResult}(T, T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalAnd<T, TOther, TResult>(this IBitwiseOperators<T, TOther, TResult> left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
            => LogicalAnd<T, TOther, TResult>((T)left, right);

        /// <summary>Computes the bitwise-or of two values.</summary>
        /// <param name="left">The value to or with <paramref name="right" />.</param>
        /// <param name="right">The value to or with <paramref name="left" />.</param>
        /// <returns>The bitwise-or of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalOr<T, TOther, TResult>(this T left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left | right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IBitwiseOperatorsCompatibility<T, TOther, TResult>>().LogicalOr(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="LogicalOr{T, TOther, TResult}(T, T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalOr<T, TOther, TResult>(this IBitwiseOperators<T, TOther, TResult> left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
            => LogicalOr<T, TOther, TResult>((T)left, right);

        /// <summary>Computes the exclusive-or of two values.</summary>
        /// <param name="left">The value to xor with <paramref name="right" />.</param>
        /// <param name="right">The value to xorwith <paramref name="left" />.</param>
        /// <returns>The exclusive-or of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalExclusiveOr<T, TOther, TResult>(this T left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => left ^ right;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IBitwiseOperatorsCompatibility<T, TOther, TResult>>().LogicalExclusiveOr(left, right);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="LogicalExclusiveOr{T, TOther, TResult}(T, T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LogicalExclusiveOr<T, TOther, TResult>(this IBitwiseOperators<T, TOther, TResult> left, TOther right) where T : IBitwiseOperators<T, TOther, TResult>, new()
            => LogicalExclusiveOr<T, TOther, TResult>((T)left, right);

        /// <summary>Computes the ones-complement representation of a given value.</summary>
        /// <param name="value">The value for which to compute its ones-complement.</param>
        /// <returns>The ones-complement of <paramref name="value" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult BitwiseComplement<T, TOther, TResult>(this T value) where T : IBitwiseOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => ~value;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => Provide.SingleInstance<T, IBitwiseOperatorsCompatibility<T, TOther, TResult>>().BitwiseComplement(value);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="BitwiseComplement{T, TOther, TResult}(T)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult BitwiseComplement<T, TOther, TResult>(this IBitwiseOperators<T, TOther, TResult> value) where T : IBitwiseOperators<T, TOther, TResult>, new()
            => BitwiseComplement<T, TOther, TResult>((T)value);
    }
}
