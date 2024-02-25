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
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;

namespace Jodosoft.Numerics
{
    public static class Number
    {
        /// <summary>Gets the additive identity of the current type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AdditiveIdentity<T>() where T : IAdditiveIdentity<T, T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.AdditiveIdentity;
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.AdditiveIdentity;
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes the number of leading zero bits in a value.</summary>
        /// <param name="value">The value whose leading zero bits are to be counted.</param>
        /// <returns>The number of leading zero bits in <paramref name="value" />.</returns>
        public static T LeadingZeroCount<T>(T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
             => T.LeadingZeroCount(value);
#else
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            T bitCount = DefaultInstance<T>.Value.CreateChecked(value!.GetByteCount() * 8L);

            if (DefaultInstance<T>.Value.IsEqualTo(value, DefaultInstance<T>.Value.Zero))
            {
                return DefaultInstance<T>.Value.CreateChecked(bitCount);
            }

            return DefaultInstance<T>.Value.LogicalExclusiveOr(DefaultInstance<T>.Value.Subtract(bitCount, DefaultInstance<T>.Value.One), DefaultInstance<T>.Value.Log2(value));
        }
#endif

        /// <summary>Computes the number of bits that are set in a value.</summary>
        /// <param name="value">The value whose set bits are to be counted.</param>
        /// <returns>The number of set bits in <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PopCount<T>(T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.PopCount(value);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.PopCount(value);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadBigEndian<T>(byte[] source, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ReadBigEndian(source, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadBigEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

        /// <summary>Reads a two's complement number from a given array, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="startIndex">The starting index from which the value should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" /> starting at <paramref name="startIndex" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadBigEndian<T>(byte[] source, int startIndex, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ReadBigEndian(source, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadBigEndian(source.AsSpan(startIndex), isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

#if HAS_SPANS
        /// <summary>Reads a two's complement number from a given span, in big-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadBigEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ReadBigEndian(source, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadBigEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif
#endif

        /// <summary>Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadLittleEndian<T>(byte[] source, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
              => T.ReadLittleEndian(source, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadLittleEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

        /// <summary>Reads a two's complement number from a given array, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="startIndex">The starting index from which the value should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" /> starting at <paramref name="startIndex" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadLittleEndian<T>(byte[] source, int startIndex, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
              => T.ReadLittleEndian(source, startIndex, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadLittleEndian(source.AsSpan(startIndex), isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

#if HAS_SPANS
        /// <summary>Reads a two's complement number from a given span, in little-endian format, and converts it to an instance of the current type.</summary>
        /// <param name="source">The array from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <returns>The value read from <paramref name="source" />.</returns>
        /// <exception cref="OverflowException"><paramref name="source" /> is not representable by <typeparamref name="T" /></exception>
        public static T ReadLittleEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
              => T.ReadLittleEndian(source, isUnsigned);
#else
        {
            if (!DefaultInstance<T>.Value.TryReadLittleEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif
#endif

        /// <summary>Rotates a value left by a given amount.</summary>
        /// <param name="value">The value which is rotated left by <paramref name="rotateAmount" />.</param>
        /// <param name="rotateAmount">The amount by which <paramref name="value" /> is rotated left.</param>
        /// <returns>The result of rotating <paramref name="value" /> left by <paramref name="rotateAmount" />.</returns>
        public static T RotateLeft<T>(T value, int rotateAmount) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
              => T.RotateLeft(value, rotateAmount);
#else
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            int bitCount = checked(value!.GetByteCount() * 8);
            return DefaultInstance<T>.Value.LogicalOr(DefaultInstance<T>.Value.LeftShift(value, rotateAmount), DefaultInstance<T>.Value.RightShift(value, bitCount - rotateAmount));
        }
#endif

        /// <summary>Rotates a value right by a given amount.</summary>
        /// <param name="value">The value which is rotated right by <paramref name="rotateAmount" />.</param>
        /// <param name="rotateAmount">The amount by which <paramref name="value" /> is rotated right.</param>
        /// <returns>The result of rotating <paramref name="value" /> right by <paramref name="rotateAmount" />.</returns>
        public static T RotateRight<T>(T value, int rotateAmount) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
              => T.RotateRight(value, rotateAmount);
#else
        {
            if (value is null) throw new ArgumentNullException(nameof(value));

            int bitCount = checked(value!.GetByteCount() * 8);
            return DefaultInstance<T>.Value.LogicalOr(DefaultInstance<T>.Value.RightShift(value, rotateAmount), DefaultInstance<T>.Value.LeftShift(value, bitCount - rotateAmount));
        }
#endif

        /// <summary>Computes the number of trailing zero bits in a value.</summary>
        /// <param name="value">The value whose trailing zero bits are to be counted.</param>
        /// <returns>The number of trailing zero bits in <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T TrailingZeroCount<T>(T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.TrailingZeroCount(value);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.TrailingZeroCount(value);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

#if HAS_SPANS
        /// <summary>Tries to read a two's complement number from a span, in big-endian format, and convert it to an instance of the current type.</summary>
        /// <param name="source">The span from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <param name="value">On return, contains the value read from <paramref name="source" /> or <c>default</c> if a value could not be read.</param>
        /// <returns><c>true</c> if the value was succesfully read from <paramref name="source" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadBigEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned, out T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.TryReadBigEndian(source, isUnsigned, out value);
#else
            => DefaultInstance<T>.Value.TryReadBigEndian(source, isUnsigned, out value);
#endif
#endif

#if HAS_SPANS
        /// <summary>Tries to read a two's complement number from a span, in little-endian format, and convert it to an instance of the current type.</summary>
        /// <param name="source">The span from which the two's complement number should be read.</param>
        /// <param name="isUnsigned"><c>true</c> if <paramref name="source" /> represents an unsigned two's complement number; otherwise, <c>false</c> to indicate it represents a signed two's complement number.</param>
        /// <param name="value">On return, contains the value read from <paramref name="source" /> or <c>default</c> if a value could not be read.</param>
        /// <returns><c>true</c> if the value was succesfully read from <paramref name="source" />; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryReadLittleEndian<T>(ReadOnlySpan<byte> source, bool isUnsigned, out T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.TryReadLittleEndian(source, isUnsigned, out value);
#else
            => DefaultInstance<T>.Value.TryReadLittleEndian(source, isUnsigned, out value);
#endif
#endif

        /// <summary>Gets an instance of the binary type in which all bits are set.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AllBitsSet<T>() where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.AllBitsSet;
#else
            => DefaultInstance<T>.Value.BitwiseComplement(DefaultInstance<T>.Value.Zero);
#endif

        /// <summary>Determines if a value is a power of two.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a power of two; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2<T>(T value) where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsPow2(value);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.IsPow2(value);
#pragma warning restore CS0618 // Type or member is obsolete
#endif

        /// <summary>Computes the log2 of a value.</summary>
        /// <param name="value">The value whose log2 is to be computed.</param>
        /// <returns>The log2 of <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log2<T>(T value) where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log2(value);
#else
#pragma warning disable CS0618 // Type or member is obsolete
            => DefaultInstance<T>.Value.Log2(value);
#pragma warning restore CS0618 // Type or member is obsolete
#endif
    }
}
