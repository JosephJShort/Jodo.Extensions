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
    public static class ShiftOperatorsExtensions
    {
        /// <summary>Shifts a value left by a given amount.</summary>
        /// <param name="value">The value which is shifted left by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted left.</param>
        /// <returns>The result of shifting <paramref name="value" /> left by <paramref name="shiftAmount" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LeftShift<T, TOther, TResult>(this T value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => value << shiftAmount;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => SingleInstance.Of<T>().Provide().LeftShift(value, shiftAmount);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="LeftShift{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult LeftShift<T, TOther, TResult>(this IShiftOperators<T, TOther, TResult> value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
            => LeftShift<T, TOther, TResult>((T)value, shiftAmount);

        /// <summary>Shifts a value right by a given amount.</summary>
        /// <param name="value">The value which is shifted right by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted right.</param>
        /// <returns>The result of shifting <paramref name="value" /> right by <paramref name="shiftAmount" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult RightShift<T, TOther, TResult>(this T value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => value >> shiftAmount;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => SingleInstance.Of<T>().Provide().RightShift(value, shiftAmount);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="RightShift{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult RightShift<T, TOther, TResult>(this IShiftOperators<T, TOther, TResult> value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
            => RightShift<T, TOther, TResult>((T)value, shiftAmount);

        /// <summary>Shifts a value right by a given amount.</summary>
        /// <param name="value">The value which is shifted right by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted right.</param>
        /// <returns>The result of shifting <paramref name="value" /> right by <paramref name="shiftAmount" />.</returns>
        /// <remarks>
        ///     Provides cross-compatibility for targets with and without the
        ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult UnsignedRightShift<T, TOther, TResult>(this T value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
#if HAS_SYSTEM_NUMERICS
            => value >>> shiftAmount;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => SingleInstance.Of<T>().Provide().UnsignedRightShift(value, shiftAmount);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <inheritdoc cref="UnsignedRightShift{T, TOther, TResult}(T, TOther)"/>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static TResult UnsignedRightShift<T, TOther, TResult>(this IShiftOperators<T, TOther, TResult> value, TOther shiftAmount) where T : IShiftOperators<T, TOther, TResult>, new()
            => UnsignedRightShift<T, TOther, TResult>((T)value, shiftAmount);
    }
}
