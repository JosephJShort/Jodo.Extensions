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
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using Jodosoft.Numerics.Compatibility;
using Jodosoft.Primitives;
using Jodosoft.Primitives.Compatibility;

// Justification: This is the preferred alternative API for obsolete interface members in Jodosoft.Numerics.Compatibility
#pragma warning disable CS0618 // Type or member is obsolete

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
            => SingleInstance.Of<T>().Provide().AdditiveIdentity;
#endif

        /// <summary>Computes the number of leading zero bits in a value.</summary>
        /// <param name="value">The value whose leading zero bits are to be counted.</param>
        /// <returns>The number of leading zero bits in <paramref name="value" />.</returns>
        public static T LeadingZeroCount<T>(T value) where T : IBinaryInteger<T>, new()
#if HAS_SYSTEM_NUMERICS
             => T.LeadingZeroCount(value);
#else
        {
            throw new NotImplementedException();
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
            => SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().PopCount(value);
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
#if HAS_SPANS
            if (!TryReadBigEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
#else
            return SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().ReadBigEndian(source, isUnsigned);
#endif
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
#if HAS_SPANS
            if (!TryReadBigEndian(source.AsSpan(startIndex), isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
#else
            return SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().ReadBigEndian(source, startIndex, isUnsigned);
#endif
        }
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
#if HAS_SPANS
            if (!TryReadLittleEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
#else
            return SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().ReadLittleEndian(source, isUnsigned);
#endif
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
#if HAS_SPANS
            if (!TryReadLittleEndian(source.AsSpan(startIndex), isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
#else
            return SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().ReadLittleEndian(source, startIndex, isUnsigned);
#endif
        }
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
            return value.LeftShift(rotateAmount).LogicalOr(value.RightShift(bitCount - rotateAmount));
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
            return value.RightShift(rotateAmount).LogicalOr(value.LeftShift(bitCount - rotateAmount));
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
            => SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().TrailingZeroCount(value);
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
            if (!SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().TryReadBigEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

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
            if (!SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().TryReadLittleEndian(source, isUnsigned, out T value))
            {
                throw new OverflowException();
            }
            return value;
        }
#endif

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
            => SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().TryReadBigEndian(source, isUnsigned, out value);
#endif

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
            => SingleInstance.Of<T>().Provide<IBinaryIntegerCompatibility<T>>().TryReadLittleEndian(source, isUnsigned, out value);
#endif

#endif

        /// <summary>Gets an instance of the binary type in which all bits are set.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T AllBitsSet<T>() where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.AllBitsSet;
#else
            => SingleInstance.Of<T>().Provide<IBitwiseOperatorsCompatibility<T, T, T>>().BitwiseComplement(SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Zero);
#endif

        /// <summary>Determines if a value is a power of two.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a power of two; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPow2<T>(T value) where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsPow2(value);
#else
            => SingleInstance.Of<T>().Provide<IBinaryNumberCompatibility<T>>().IsPow2(value);
#endif

        /// <summary>Computes the log2 of a value.</summary>
        /// <param name="value">The value whose log2 is to be computed.</param>
        /// <returns>The log2 of <paramref name="value" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Log2<T>(T value) where T : IBinaryNumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Log2(value);
#else
            => SingleInstance.Of<T>().Provide<IBinaryNumberCompatibility<T>>().Log2(value);
#endif

        /// <summary>Gets the smallest value such that can be added to <c>0</c> that does not result in <c>0</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Epsilon<T>() where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Epsilon;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().Epsilon;
#endif

        /// <summary>Gets a value that represents <c>NaN</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NaN<T>() where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.NaN;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().NaN;
#endif

        /// <summary>Gets a value that represents negative <c>infinity</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NegativeInfinity<T>() where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.NegativeInfinity;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().NegativeInfinity;
#endif

        /// <summary>Gets a value that represents negative <c>zero</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T NegativeZero<T>() where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.NegativeZero;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().NegativeZero;
#endif

        /// <summary>Gets a value that represents positive <c>infinity</c>.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T PositiveInfinity<T>() where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.PositiveInfinity;
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().PositiveInfinity;
#endif

        /// <summary>Computes the arc-tangent for the quotient of two values.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />.</returns>
        /// <remarks>This computes <c>arctan(y / x)</c> in the interval <c>[-PI, +PI]</c> radians.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atan2<T>(T y, T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Atan2(y, x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().Atan2(y, x);
#endif

        /// <summary>Computes the arc-tangent for the quotient of two values and divides the result by <c>pi</c>.</summary>
        /// <param name="y">The y-coordinate of a point.</param>
        /// <param name="x">The x-coordinate of a point.</param>
        /// <returns>The arc-tangent of <paramref name="y" /> divided-by <paramref name="x" />, divided by <c>pi</c>.</returns>
        /// <remarks>This computes <c>arctan(y / x) / PI</c> in the interval <c>[-1, +1]</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Atan2Pi<T>(T y, T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Atan2Pi(y, x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().Atan2Pi(y, x);
#endif

        /// <summary>Decrements a value to the largest value that compares less than a given value.</summary>
        /// <param name="x">The value to be bitwise decremented.</param>
        /// <returns>The largest value that compares less than <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T BitDecrement<T>(T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.BitDecrement(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().BitDecrement(x);
#endif

        /// <summary>Increments a value to the smallest value that compares greater than a given value.</summary>
        /// <param name="x">The value to be bitwise incremented.</param>
        /// <returns>The smallest value that compares greater than <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T BitIncrement<T>(T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.BitIncrement(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().BitIncrement(x);
#endif

        /// <summary>Computes the fused multiply-add of three values.</summary>
        /// <param name="left">The value which <paramref name="right" /> multiplies.</param>
        /// <param name="right">The value which multiplies <paramref name="left" />.</param>
        /// <param name="addend">The value that is added to the product of <paramref name="left" /> and <paramref name="right" />.</param>
        /// <returns>The result of <paramref name="left" /> times <paramref name="right" /> plus <paramref name="addend" /> computed as one ternary operation.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T FusedMultiplyAdd<T>(T left, T right, T addend) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.FusedMultiplyAdd(left, right, addend);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().FusedMultiplyAdd(left, right, addend);
#endif

        /// <summary>Computes the remainder of two values as specified by IEEE 754.</summary>
        /// <param name="left">The value which <paramref name="right" /> divides.</param>
        /// <param name="right">The value which divides <paramref name="left" />.</param>
        /// <returns>The remainder of <paramref name="left" /> divided-by <paramref name="right" /> as specified by IEEE 754.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Ieee754Remainder<T>(T left, T right) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Ieee754Remainder(left, right);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().Ieee754Remainder(left, right);
#endif

        /// <summary>Computes the integer logarithm of a value.</summary>
        /// <param name="x">The value whose integer logarithm is to be computed.</param>
        /// <returns>The integer logarithm of <paramref name="x" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int ILogB<T>(T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ILogB(x);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().ILogB(x);
#endif

        /// <summary>Performs a linear interpolation between two values based on the given weight.</summary>
        /// <param name="value1">The first value, which is intended to be the lower bound.</param>
        /// <param name="value2">The second value, which is intended to be the upper bound.</param>
        /// <param name="amount">A value, intended to be between 0 and 1, that indicates the weight of the interpolation.</param>
        /// <returns>The interpolated value.</returns>
        /// <remarks>This method presumes inputs are well formed and does not validate that <c>value1 &lt; value2</c> nor that <c>0 &lt;= amount &lt;= 1</c>.</remarks>
        public static T Lerp<T>(T value1, T value2, T amount) where T : IFloatingPointIeee754<T>, new()
#if NET8_0_OR_GREATER
            => T.Lerp(value1, value2, amount);
#else
            => value1.Multiply(One<T>().Subtract(amount)).Add(value2.Multiply(amount));
#endif

        /// <summary>Computes an estimate of the reciprocal of a value.</summary>
        /// <param name="x">The value whose estimate of the reciprocal is to be computed.</param>
        /// <returns>An estimate of the reciprocal of <paramref name="x" />.</returns>
        public static T ReciprocalEstimate<T>(T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ReciprocalEstimate(x);
#else
            => One<T>().Divide(x);
#endif

        /// <summary>Computes an estimate of the reciprocal square root of a value.</summary>
        /// <param name="x">The value whose estimate of the reciprocal square root is to be computed.</param>
        /// <returns>An estimate of the reciprocal square root of <paramref name="x" />.</returns>
        public static T ReciprocalSqrtEstimate<T>(T x) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ReciprocalSqrtEstimate(x);
#else
            => One<T>().Divide(MathN2.Sqrt(x));
#endif

        /// <summary>Computes the product of a value and its base-radix raised to the specified power.</summary>
        /// <param name="x">The value which base-radix raised to the power of <paramref name="n" /> multiplies.</param>
        /// <param name="n">The value to which base-radix is raised before multipliying <paramref name="x" />.</param>
        /// <returns>The product of <paramref name="x" /> and base-radix raised to the power of <paramref name="n" />.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T ScaleB<T>(T x, int n) where T : IFloatingPointIeee754<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.ScaleB(x, n);
#else
            => SingleInstance.Of<T>().Provide<IFloatingPointIeee754Compatibility<T>>().ScaleB(x, n);
#endif

        /// <summary>Gets the minimum value of the current type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinValue<T>() where T : IMinMaxValue<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MinValue;
#else
            => SingleInstance.Of<T>().Provide().MinValue;
#endif

        /// <summary>Gets the maximum value of the current type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxValue<T>() where T : IMinMaxValue<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MaxValue;
#else
            => SingleInstance.Of<T>().Provide().MaxValue;
#endif

        /// <summary>Gets the multiplicative identity of the current type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MultiplicativeIdentity<T>() where T : IMultiplicativeIdentity<T, T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MultiplicativeIdentity;
#else
            => SingleInstance.Of<T>().Provide().MultiplicativeIdentity;
#endif

        /// <summary>Clamps a value to an inclusive minimum and maximum value.</summary>
        /// <param name="value">The value to clamp.</param>
        /// <param name="min">The inclusive minimum to which <paramref name="value" /> should clamp.</param>
        /// <param name="max">The inclusive maximum to which <paramref name="value" /> should clamp.</param>
        /// <returns>The result of clamping <paramref name="value" /> to the inclusive range of <paramref name="min" /> and <paramref name="max" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="min" /> is greater than <paramref name="max" />.</exception>
        public static T Clamp<T>(T value, T min, T max) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Clamp(value, min, max);
#else
        {
            if (min.IsGreaterThan(max))
            {
                throw new ArgumentException($"'{min}' cannot be greater than {max}.");
            }
            T result = value;
            result = Max(result, min);
            result = Min(result, max);
            return result;
        }
#endif

        /// <summary>Copies the sign of a value to the sign of another value..</summary>
        /// <param name="value">The value whose magnitude is used in the result.</param>
        /// <param name="sign">The value whose sign is used in the result.</param>
        /// <returns>A value with the magnitude of <paramref name="value" /> and the sign of <paramref name="sign" />.</returns>
        public static T CopySign<T>(T value, T sign) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.CopySign(value, sign);
#else
        {
            T result = value;
            if (IsNegative(value) != IsNegative(sign))
            {
                result = checked(result.Negative());
            }
            return result;
        }
#endif

        /// <summary>Compares two values to compute which is greater.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPoint{T}" /> this method matches the IEEE 754:2019 <c>maximum</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        public static T Max<T>(T x, T y) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Max(x, y);
#else
        {
            if (x.IsNotEqualTo(y))
            {
                if (!IsNaN(x))
                {
                    return y.IsLessThan(x) ? x : y;
                }
                return x;
            }
            return IsNegative(y) ? x : y;
        }
#endif

        /// <summary>Compares two values to compute which is greater and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPoint{T}" /> this method matches the IEEE 754:2019 <c>maximumNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        public static T MaxNumber<T>(T x, T y) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MaxNumber(x, y);
#else
        {
            if (x.IsNotEqualTo(y))
            {
                if (!IsNaN(y))
                {
                    return y.IsLessThan(x) ? x : y;
                }
                return x;
            }
            return IsNegative(y) ? x : y;
        }
#endif

        /// <summary>Compares two values to compute which is lesser.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPoint{T}" /> this method matches the IEEE 754:2019 <c>minimum</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        public static T Min<T>(T x, T y) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Min(x, y);
#else
        {
            if (x.IsNotEqualTo(y) && !IsNaN(x))
            {
                return x.IsLessThan(y) ? x : y;
            }
            return IsNegative(x) ? x : y;
        }
#endif

        /// <summary>Compares two values to compute which is lesser and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPoint{T}" /> this method matches the IEEE 754:2019 <c>minimumNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        public static T MinNumber<T>(T x, T y) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MinNumber(x, y);
#else
        {
            if (x.IsNotEqualTo(y))
            {
                if (!IsNaN(y))
                {
                    return x.IsLessThan(y) ? x : y;
                }
                return x;
            }
            return IsNegative(x) ? x : y;
        }
#endif

        /// <summary>Computes the sign of a value.</summary>
        /// <param name="value">The value whose sign is to be computed.</param>
        /// <returns>A positive value if <paramref name="value" /> is positive, <see cref="Zero{T}" /> if <paramref name="value" /> is zero, and a negative value if <paramref name="value" /> is negative.</returns>
        /// <remarks>It is recommended that a function return <c>1</c>, <c>0</c>, and <c>-1</c>, respectively.</remarks>
        public static int Sign<T>(T value) where T : INumber<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Sign(value);
#else
        {
            if (value.IsNotEqualTo(Zero<T>()))
            {
                return IsNegative(value) ? -1 : +1;
            }
            return 0;
        }
#endif

        /// <summary>Gets the value <c>1</c> for the type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T One<T>() where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.One;
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().One;
#endif

        /// <summary>Gets the radix, or base, for the type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Radix<T>() where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Radix;
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Radix;
#endif

        /// <summary>Gets the value <c>0</c> for the type.</summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Zero<T>() where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Zero;
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Zero;
#endif

        /// <summary>Computes the absolute of a value.</summary>
        /// <param name="value">The value for which to get its absolute.</param>
        /// <returns>The absolute of <paramref name="value" />.</returns>
        /// <exception cref="OverflowException">The absolute of <paramref name="value" /> is not representable by <typeparamref name="T" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Abs<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Abs(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Abs(value);
#endif

        /// <summary>Creates an instance of the current type from a value, throwing an overflow exception for any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        /// <exception cref="OverflowException"><paramref name="value" /> is not representable by <typeparamref name="T" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateChecked<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new()
#if HAS_SYSTEM_NUMERICS
            => T.CreateChecked(value);
#else
        {
            T? result;
            if (typeof(TOther) == typeof(T))
            {
                result = (T)(object)value;
            }
            else if (!SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().TryConvertFromChecked(value, out result) && !SingleInstance.Of<TOther>().Provide<INumberBaseCompatibility<TOther>>().TryConvertToChecked<T>(value, out result))
            {
                throw new NotSupportedException();
            }
            return result;
        }
#endif

        /// <summary>Creates an instance of the current type from a value, saturating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />, saturating if <paramref name="value" /> falls outside the representable range of <typeparamref name="T" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateSaturating<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new()
#if HAS_SYSTEM_NUMERICS
            => T.CreateSaturating(value);
#else
        {
            T? result;

            if (typeof(TOther) == typeof(T))
            {
                result = (T)(object)value;
            }
            else if (!SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().TryConvertFromSaturating(value, out result) && !SingleInstance.Of<TOther>().Provide<INumberBaseCompatibility<TOther>>().TryConvertToSaturating<T>(value, out result))
            {
                throw new NotSupportedException();
            }
            return result;
        }
#endif

        /// <summary>Creates an instance of the current type from a value, truncating any values that fall outside the representable range of the current type.</summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <typeparam name="TOther">The type of <paramref name="value" />.</typeparam>
        /// <param name="value">The value which is used to create the instance of <typeparamref name="T" />.</param>
        /// <returns>An instance of <typeparamref name="T" /> created from <paramref name="value" />, truncating if <paramref name="value" /> falls outside the representable range of <typeparamref name="T" />.</returns>
        /// <exception cref="NotSupportedException"><typeparamref name="TOther" /> is not supported.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T CreateTruncating<T, TOther>(TOther value)
            where T : INumberBase<T>, new()
            where TOther : INumberBase<TOther>, new()
#if HAS_SYSTEM_NUMERICS
            => T.CreateTruncating(value);
#else
        {
            T? result;

            if (typeof(TOther) == typeof(T))
            {
                result = (T)(object)value;
            }
            else if (!SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().TryConvertFromTruncating(value, out result) && !SingleInstance.Of<TOther>().Provide<INumberBaseCompatibility<TOther>>().TryConvertToTruncating<T>(value, out result))
            {
                throw new NotSupportedException();
            }

            return result;
        }
#endif

        /// <summary>Determines if a value is in its canonical representation.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is in its canonical representation; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsCanonical<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsCanonical(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsCanonical(value);
#endif

        /// <summary>Determines if a value represents a complex value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a complex number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where either <c>a</c> or <c>b</c> is zero. In other words, it excludes real numbers and pure imaginary numbers.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsComplexNumber<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsComplexNumber(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsComplexNumber(value);
#endif

        /// <summary>Determines if a value represents an even integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an even integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>2.0</c> will return <c>true</c> while <c>2.2</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger{T}(T)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is not even nor odd.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsEvenInteger<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsEvenInteger(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsEvenInteger(value);
#endif

        /// <summary>Determines if a value is finite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is finite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsInfinity{T}(T)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsFinite<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsFinite(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsFinite(value);
#endif

        /// <summary>Determines if a value represents a pure imaginary value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a pure imaginary number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>false</c> for a complex number <c>a + bi</c> where <c>a</c> is non-zero, as that number is not purely imaginary.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsImaginaryNumber<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsImaginaryNumber(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsImaginaryNumber(value);
#endif

        /// <summary>Determines if a value is infinite.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is infinite; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returning <c>false</c> does not imply that <see cref="IsFinite{T}(T)" /> will return <c>true</c>. <c>NaN</c> is not finite nor infinite.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInfinity<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsInfinity(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsInfinity(value);
#endif

        /// <summary>Determines if a value represents an integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an integer; otherwise, <c>false</c>.</returns>
        /// <remarks>This correctly handles floating-point values and so <c>2.0</c> and <c>3.0</c> will return <c>true</c> while <c>2.2</c> and <c>3.3</c> will return <c>false</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsInteger<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsInteger(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsInteger(value);
#endif

        /// <summary>Determines if a value is NaN.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is NaN; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNaN<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsNaN(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsNaN(value);
#endif

        /// <summary>Determines if a value represents a negative real number.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> represents negative zero or a negative real number; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>If this type has signed zero, then <c>-0</c> is also considered negative.</para>
        ///     <para>This function returning <c>false</c> does not imply that <see cref="IsPositive{T}(T)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegative<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsNegative(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsNegative(value);
#endif

        /// <summary>Determines if a value is negative infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is negative infinity; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNegativeInfinity<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsNegativeInfinity(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsNegativeInfinity(value);
#endif

        /// <summary>Determines if a value is normal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is normal; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsNormal<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsNormal(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsNormal(value);
#endif

        /// <summary>Determines if a value represents an odd integral value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is an odd integer; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>This correctly handles floating-point values and so <c>3.0</c> will return <c>true</c> while <c>3.3</c> will return <c>false</c>.</para>
        ///     <para>This functioning returning <c>false</c> does not imply that <see cref="IsOddInteger{T}(T)" /> will return <c>true</c>. A number with a fractional portion, <c>3.3</c>, is neither even nor odd.</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsOddInteger<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsOddInteger(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsOddInteger(value);
#endif

        /// <summary>Determines if a value represents zero or a positive real number.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> represents (positive) zero or a positive real number; otherwise, <c>false</c>.</returns>
        /// <remarks>
        ///     <para>If this type has signed zero, then <c>-0</c> is not considered positive, but <c>+0</c> is.</para>
        ///     <para>This function returning <c>false</c> does not imply that <see cref="IsNegative{T}(T)" /> will return <c>true</c>. A complex number, <c>a + bi</c> for non-zero <c>b</c>, is not positive nor negative</para>
        /// </remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositive<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsPositive(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsPositive(value);
#endif

        /// <summary>Determines if a value is positive infinity.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is positive infinity; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsPositiveInfinity<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsPositiveInfinity(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsPositiveInfinity(value);
#endif

        /// <summary>Determines if a value represents a real value.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is a real number; otherwise, <c>false</c>.</returns>
        /// <remarks>This function returns <c>true</c> for a complex number <c>a + bi</c> where <c>b</c> is zero.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsRealNumber<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsRealNumber(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsRealNumber(value);
#endif

        /// <summary>Determines if a value is subnormal.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is subnormal; otherwise, <c>false</c>.</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsSubnormal<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsSubnormal(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsSubnormal(value);
#endif

        /// <summary>Determines if a value is zero.</summary>
        /// <param name="value">The value to be checked.</param>
        /// <returns><c>true</c> if <paramref name="value" /> is zero; otherwise, <c>false</c>.</returns>
        /// <remarks>This function treats both positive and negative zero as zero and so will return <c>true</c> for <c>+0.0</c> and <c>-0.0</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool IsZero<T>(T value) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.IsZero(value);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().IsZero(value);
#endif

        /// <summary>Compares two values to compute which is greater.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{T}" /> this method matches the IEEE 754:2019 <c>maximumMagnitude</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxMagnitude<T>(T x, T y) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MaxMagnitude(x, y);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().MaxMagnitude(x, y);
#endif

        /// <summary>Compares two values to compute which has the greater magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is greater than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{T}" /> this method matches the IEEE 754:2019 <c>maximumMagnitudeNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MaxMagnitudeNumber<T>(T x, T y) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MaxMagnitudeNumber(x, y);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().MaxMagnitudeNumber(x, y);
#endif

        /// <summary>Compares two values to compute which is lesser.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{T}" /> this method matches the IEEE 754:2019 <c>minimumMagnitude</c> function. This requires NaN inputs to be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinMagnitude<T>(T x, T y) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MinMagnitude(x, y);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().MinMagnitude(x, y);
#endif

        /// <summary>Compares two values to compute which has the lesser magnitude and returning the other value if an input is <c>NaN</c>.</summary>
        /// <param name="x">The value to compare with <paramref name="y" />.</param>
        /// <param name="y">The value to compare with <paramref name="x" />.</param>
        /// <returns><paramref name="x" /> if it is less than <paramref name="y" />; otherwise, <paramref name="y" />.</returns>
        /// <remarks>For <see cref="IFloatingPointIeee754{T}" /> this method matches the IEEE 754:2019 <c>minimumMagnitudeNumber</c> function. This requires NaN inputs to not be propagated back to the caller and for <c>-0.0</c> to be treated as less than <c>+0.0</c>.</remarks>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T MinMagnitudeNumber<T>(T x, T y) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.MinMagnitudeNumber(x, y);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().MinMagnitudeNumber(x, y);
#endif

        /// <summary>Parses a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="s" /> is <c>null</c>.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="T" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(string s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Parse(s, style, provider);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Parse(s, style, provider);
#endif

        /// <summary>Tries to parse a string into a value.</summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.TryParse(s, style, provider, out result);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().TryParse(s, style, provider, out result);
#endif

#if HAS_SPANS

        /// <summary>Parses a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <returns>The result of parsing <paramref name="s" />.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        /// <exception cref="FormatException"><paramref name="s" /> is not in the correct format.</exception>
        /// <exception cref="OverflowException"><paramref name="s" /> is not representable by <typeparamref name="T" />.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static T Parse<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.Parse(s, style, provider);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().Parse(s, style, provider);
#endif

        /// <summary>Tries to parse a span of characters into a value.</summary>
        /// <param name="s">The span of characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information about <paramref name="s" />.</param>
        /// <param name="result">On return, contains the result of successfully parsing <paramref name="s" /> or an undefined value on failure.</param>
        /// <returns><c>true</c> if <paramref name="s" /> was successfully parsed; otherwise, <c>false</c>.</returns>
        /// <exception cref="ArgumentException"><paramref name="style" /> is not a supported <see cref="NumberStyles" /> value.</exception>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static bool TryParse<T>(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, [MaybeNullWhen(false)] out T result) where T : INumberBase<T>, new()
#if HAS_SYSTEM_NUMERICS
            => T.TryParse(s, style, provider, out result);
#else
            => SingleInstance.Of<T>().Provide<INumberBaseCompatibility<T>>().TryParse(s, style, provider, out result);
#endif

#endif

    }
}

#pragma warning restore CS0618 // Type or member is obsolete
