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
    /// <summary>Defines a mechanism for shifting a value by another value.</summary>
    /// <typeparam name="T">The type that implements this interface.</typeparam>
    /// <typeparam name="TOther">The type used to specify the amount by which <typeparamref name="T" /> should be shifted.</typeparam>
    /// <typeparam name="TResult">The type that contains the result of shifting <typeparamref name="T" /> by <typeparamref name="TResult" />.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IShiftOperatorsCompatibility<T, TOther, TResult>
        where T : IShiftOperators<T, TOther, TResult>?, new()
    {
        /// <summary>Shifts a value left by a given amount.</summary>
        /// <param name="value">The value which is shifted left by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted left.</param>
        /// <returns>The result of shifting <paramref name="value" /> left by <paramref name="shiftAmount" />.</returns>
        /// <remarks>Use <c>value.LeftShift(shiftAmount)</c> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use value.LeftShift(shiftAmount) to ensure compatibility with all .NET targets.")]
        TResult LeftShift(T? value, TOther? shiftAmount);

        /// <summary>Shifts a value right by a given amount.</summary>
        /// <param name="value">The value which is shifted right by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted right.</param>
        /// <returns>The result of shifting <paramref name="value" /> right by <paramref name="shiftAmount" />.</returns>
        /// <remarks>Use <c>value.RightShift(shiftAmount)</c> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use value.RightShift(shiftAmount) to ensure compatibility with all .NET targets.")]
        TResult RightShift(T? value, TOther? shiftAmount);

        /// <summary>Shifts a value right by a given amount.</summary>
        /// <param name="value">The value which is shifted right by <paramref name="shiftAmount" />.</param>
        /// <param name="shiftAmount">The amount by which <paramref name="value" /> is shifted right.</param>
        /// <returns>The result of shifting <paramref name="value" /> right by <paramref name="shiftAmount" />.</returns>
        /// <remarks>Use <c>value.UnsignedRightShift(shiftAmount)</c> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use value.UnsignedRightShift(shiftAmount) to ensure compatibility with all .NET targets.")]
        TResult UnsignedRightShift(T value, TOther shiftAmount);
    }
}

#endif
