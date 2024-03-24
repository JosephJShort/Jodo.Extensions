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

using System;
using Jodosoft.Primitives;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines an integer type that is represented in a base-2 format.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
    /// </remarks>
    public interface IBinaryInteger<TSelf>
        : IProvider<IBinaryIntegerCompatibility<TSelf>>,
          IBinaryNumber<TSelf>,
          IShiftOperators<TSelf, int, TSelf>
        where TSelf : IBinaryInteger<TSelf>?, new()
    {
        /// <summary>Gets the number of bytes that will be written as part of <see cref="TryWriteLittleEndian(Span{byte}, out int)" />.</summary>
        /// <returns>The number of bytes that will be written as part of <see cref="TryWriteLittleEndian(Span{byte}, out int)" />.</returns>
        int GetByteCount();

        /// <summary>Gets the length, in bits, of the shortest two's complement representation of the current value.</summary>
        /// <returns>The length, in bits, of the shortest two's complement representation of the current value.</returns>
        int GetShortestBitLength();

#if HAS_SPANS
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
