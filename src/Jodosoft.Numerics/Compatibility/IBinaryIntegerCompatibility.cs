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

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines an integer type that is represented in a base-2 format.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility for <see langword="static"/> interface members introduced with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> in .NET 7.
    /// </remarks>
    public interface IBinaryIntegerCompatibility<TSelf>
        where TSelf : IBinaryInteger<TSelf>?, new()
    {
        /// <summary>Computes the number of leading zero bits in a value.</summary>
        /// <param name="value">The value whose leading zero bits are to be counted.</param>
        /// <returns>The number of leading zero bits in <paramref name="value" />.</returns>
        /// <remarks>Use <see cref="Number.LeadingZeroCount{T}(T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.LeadingZeroCount to ensure compatibility with all .NET targets.")]
        TSelf LeadingZeroCount(TSelf value);

        /// <summary>Computes the number of bits that are set in a value.</summary>
        /// <param name="value">The value whose set bits are to be counted.</param>
        /// <returns>The number of set bits in <paramref name="value" />.</returns>
        /// <remarks>Use <see cref="Number.PopCount{T}(T)"/> to ensure compatibility with all .NET targets.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.PopCount to ensure compatibility with all .NET targets.")]
        TSelf PopCount(TSelf value);

        /// <summary>Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadBigEndian(byte[] source, bool isUnsigned);

        /// <summary>Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="startIndex">The starting index from which the value should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" /> starting at <paramref name="startIndex" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadBigEndian(byte[] source, int startIndex, bool isUnsigned);

        /// <summary>Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadLittleEndian(byte[] source, bool isUnsigned);

        /// <summary>Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="startIndex">The starting index from which the value should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" /> starting at <paramref name="startIndex" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadLittleEndian(byte[] source, int startIndex, bool isUnsigned);

        /// <summary>Rotates a value left by a given amount.</summary>
        /// <param name="value">The value which is rotated left by <paramref name="rotateAmount" />.</param>
        /// <param name="rotateAmount">The amount by which <paramref name="value" /> is rotated left.</param>
        /// <returns>The result of rotating <paramref name="value" /> left by <paramref name="rotateAmount" />.</returns>
        TSelf RotateLeft(TSelf value, int rotateAmount);

        /// <summary>Rotates a value right by a given amount.</summary>
        /// <param name="value">The value which is rotated right by <paramref name="rotateAmount" />.</param>
        /// <param name="rotateAmount">The amount by which <paramref name="value" /> is rotated right.</param>
        /// <returns>The result of rotating <paramref name="value" /> right by <paramref name="rotateAmount" />.</returns>
        TSelf RotateRight(TSelf value, int rotateAmount);

        /// <summary>Computes the number of trailing zero bits in a value.</summary>
        /// <param name="value">The value whose trailing zero bits are to be counted.</param>
        /// <returns>The number of trailing zero bits in <paramref name="value" />.</returns>
        TSelf TrailingZeroCount(TSelf value);

#if HAS_SPANS

        /// <summary>Reads a two's complement number from a given span, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned);

        /// <summary>Reads a two's complement number from a given span, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="TSelf" /></exception>
        TSelf ReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned);

        /// <summary>Tries to read a two's complement number from a span, in big-endian format, and convert it to an instance of the current type.</summary>
        /// <param name="source">The span from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <param name="value">On return, contains the value read from <paramref name="source" /> or <c>default</c> if a value could not be read.</param>
        /// <returns><c>true</c> if the value was succesfully read from <paramref name="source" />; otherwise, <c>false</c>.</returns>
        bool TryReadBigEndian(ReadOnlySpan<byte> source, bool isUnsigned, out TSelf value);

        /// <summary>Tries to read a two's complement number from a span, in little-endian format, and convert it to an instance of the current type.</summary>
        /// <param name="source">The span from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <param name="value">On return, contains the value read from <paramref name="source" /> or <c>default</c> if a value could not be read.</param>
        /// <returns><c>true</c> if the value was succesfully read from <paramref name="source" />; otherwise, <c>false</c>.</returns>
        bool TryReadLittleEndian(ReadOnlySpan<byte> source, bool isUnsigned, out TSelf value);
#endif
    }
}

#endif
