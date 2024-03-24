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
using System.Buffers;
using System.Text;
using System.Text.Unicode;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

#if !HAS_SYSTEM_NUMERICS

namespace Jodosoft.Numerics.Compatibility
{
    /// <summary>Defines the base of other number types.</summary>
    /// <typeparam name="TSelf">The type that implements the interface.</typeparam>
    /// <remarks>
    ///     Provides backwards-compatibility with
    ///     <see href="https://learn.microsoft.com/en-us/dotnet/standard/generics/math">generic math</see> introduced in .NET 7.
    /// </remarks>
    public interface INumberBase<TSelf> :
        IProvider<INumberBaseCompatibility<TSelf>>,
        IAdditionOperators<TSelf, TSelf, TSelf>,
        IAdditiveIdentity<TSelf, TSelf>,
        IDecrementOperators<TSelf>,
        IDivisionOperators<TSelf, TSelf, TSelf>,
        IEquatable<TSelf>,
        IEqualityOperators<TSelf, TSelf, bool>,
        IIncrementOperators<TSelf>,
        IMultiplicativeIdentity<TSelf, TSelf>,
        IMultiplyOperators<TSelf, TSelf, TSelf>,
#if HAS_SPANS
        ISpanFormattable,
        ISpanParsable<TSelf>,
#else
        IFormattable,
        IParsable<TSelf>,
#endif
        ISubtractionOperators<TSelf, TSelf, TSelf>,
        IUnaryPlusOperators<TSelf, TSelf>,
        IUnaryNegationOperators<TSelf, TSelf>
    where TSelf : INumberBase<TSelf>?, new()
    {

        bool IUtf8SpanFormattable.TryFormat(Span<byte> utf8Destination, out int bytesWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            char[]? utf16DestinationArray;
            scoped Span<char> utf16Destination;
            int destinationMaxCharCount = Encoding.UTF8.GetMaxCharCount(utf8Destination.Length);

            if (destinationMaxCharCount < 256)
            {
                utf16DestinationArray = null;
                utf16Destination = stackalloc char[256];
            }
            else
            {
                utf16DestinationArray = ArrayPool<char>.Shared.Rent(destinationMaxCharCount);
                utf16Destination = utf16DestinationArray.AsSpan(0, destinationMaxCharCount);
            }

            if (!TryFormat(utf16Destination, out int charsWritten, format, provider))
            {
                if (utf16DestinationArray != null)
                {
                    // Return rented buffers if necessary
                    ArrayPool<char>.Shared.Return(utf16DestinationArray);
                }

                bytesWritten = 0;
                return false;
            }

            // Make sure we slice the buffer to just the characters written
            utf16Destination = utf16Destination.Slice(0, charsWritten);

            OperationStatus utf8DestinationStatus = Utf8.FromUtf16(utf16Destination, utf8Destination, out _, out bytesWritten, replaceInvalidSequences: false);

            if (utf16DestinationArray != null)
            {
                // Return rented buffers if necessary
                ArrayPool<char>.Shared.Return(utf16DestinationArray);
            }

            if (utf8DestinationStatus == OperationStatus.Done)
            {
                return true;
            }

            if (utf8DestinationStatus != OperationStatus.DestinationTooSmall)
            {
                ThrowHelper.ThrowInvalidOperationException_InvalidUtf8();
            }

            bytesWritten = 0;
            return false;
        }
    }
}

#endif
