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
using Jodosoft.Primitives;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    public interface ICompatProvider<T>
    {
        T StaticCompatibility { get; }
    }

    /// <summary>Defines a floating-point type.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    public interface IFloatingPoint<TSelf>
        : IProvider<IFloatingPointCompatibility<TSelf>>
          IFloatingPointConstants<TSelf>,
          INumber<TSelf>,
          ISignedNumber<TSelf>
        where TSelf : IFloatingPoint<TSelf>?, new()
    {
        /// <summary>Gets the number of bytes that will be written as part of <see cref="TryWriteExponentLittleEndian(Span{byte}, out int)" />.</summary>
        /// <returns>The number of bytes that will be written as part of <see cref="TryWriteExponentLittleEndian(Span{byte}, out int)" />.</returns>
        int GetExponentByteCount();

        /// <summary>Gets the length, in bits, of the shortest two's complement representation of the current exponent.</summary>
        /// <returns>The length, in bits, of the shortest two's complement representation of the current exponent.</returns>
        int GetExponentShortestBitLength();

        /// <summary>Gets the length, in bits, of the current significand.</summary>
        /// <returns>The length, in bits, of the current significand.</returns>
        int GetSignificandBitLength();

        /// <summary>Gets the number of bytes that will be written as part of <see cref="TryWriteSignificandLittleEndian(Span{byte}, out int)" />.</summary>
        /// <returns>The number of bytes that will be written as part of <see cref="TryWriteSignificandLittleEndian(Span{byte}, out int)" />.</returns>
        int GetSignificandByteCount();

#if HAS_SPANS
        /// <summary>Tries to write the current exponent, in big-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the exponent was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteExponentBigEndian(Span<byte> destination, out int bytesWritten);

        /// <summary>Tries to write the current exponent, in little-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current exponent should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the exponent was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteExponentLittleEndian(Span<byte> destination, out int bytesWritten);

        /// <summary>Tries to write the current significand, in big-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the significand was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteSignificandBigEndian(Span<byte> destination, out int bytesWritten);

        /// <summary>Tries to write the current significand, in little-endian format, to a given span.</summary>
        /// <param name="destination">The span to which the current significand should be written.</param>
        /// <param name="bytesWritten">The number of bytes written to <paramref name="destination" />.</param>
        /// <returns><c>true</c> if the significand was successfully written to <paramref name="destination" />; otherwise, <c>false</c>.</returns>
        bool TryWriteSignificandLittleEndian(Span<byte> destination, out int bytesWritten);
#endif
    }
}
#endif
