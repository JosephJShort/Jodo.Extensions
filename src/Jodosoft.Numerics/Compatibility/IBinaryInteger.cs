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
    public interface IBinaryInteger<TSelf>
        : IBinaryNumber<TSelf>,
          IShiftOperators<TSelf, int, TSelf>
        where TSelf : IBinaryInteger<TSelf>?, new()
    {
        /// <summary>Computes the number of bits that are set in a value.</summary>
        /// <param name="value">The value whose set bits are to be counted.</param>
        /// <returns>The number of set bits in <paramref name="value" />.</returns>
        /// <remarks>Use <see cref="Number.PopCount{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.PopCount")]
        TSelf PopCount(TSelf value);

        /// <summary>Computes the number of trailing zeros in a value.</summary>
        /// <param name="value">The value whose trailing zeroes are to be counted.</param>
        /// <returns>The number of trailing zeros in <paramref name="value" />.</returns>
        /// <remarks>Use <see cref="Number.TrailingZeroCount{T}(T)"/>.</remarks>
        [Obsolete("Use Jodosoft.Numerics.Number.TrailingZeroCount")]
        TSelf TrailingZeroCount(TSelf value);

        /// <summary>Gets the number of bytes that will be written as part of <see cref="TryWriteLittleEndian(Span{byte}, out int)" />.</summary>
        /// <returns>The number of bytes that will be written as part of <see cref="TryWriteLittleEndian(Span{byte}, out int)" />.</returns>
        int GetByteCount();

        /// <summary>Gets the length, in bits, of the shortest two's complement representation of the current value.</summary>
        /// <returns>The length, in bits, of the shortest two's complement representation of the current value.</returns>
        int GetShortestBitLength();

#if HAS_SPANS
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

        /// <summary>Tries to write the current value, in big-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current value should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the value was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteBigEndian(Span<byte> destination, out int bytesWritten);

        /// <summary>Tries to write the current value, in little-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current value should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the value was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteLittleEndian(Span<byte> destination, out int bytesWritten);
#endif
    }
}

#endif
